using System;
using System.Diagnostics;

using SharpDX;
using SharpDX.D3DCompiler;
using SharpDX.Direct3D;
using SharpDX.Direct3D10;
using SharpDX.DXGI;
using SharpDX.Windows;
using Buffer = SharpDX.Direct3D10.Buffer;
using Device = SharpDX.Direct3D10.Device;
using DriverType = SharpDX.Direct3D10.DriverType;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSAKLogo
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var form = new RenderForm("logo ssak");

            // SwapChain description
            var desc = new SwapChainDescription()
                           {
                               BufferCount = 1,
                               ModeDescription =
                                   new ModeDescription(form.ClientSize.Width, form.ClientSize.Height,
                                                       new Rational(60, 1), Format.R8G8B8A8_UNorm),
                               IsWindowed = true,
                               OutputHandle = form.Handle,
                               SampleDescription = new SampleDescription(1, 0),
                               SwapEffect = SwapEffect.Discard,
                               Usage = Usage.RenderTargetOutput
                           };

            // Create Device and SwapChain
            Device device;
            SwapChain swapChain;
            Device.CreateWithSwapChain(DriverType.Hardware, DeviceCreationFlags.None, desc, out device, out swapChain);
            var context = device;

            // Ignore all windows events
            var factory = swapChain.GetParent<Factory>();
            factory.MakeWindowAssociation(form.Handle, WindowAssociationFlags.IgnoreAll);

            // New RenderTargetView from the backbuffer
            var backBuffer = Texture2D.FromSwapChain<Texture2D>(swapChain, 0);
            var renderView = new RenderTargetView(device, backBuffer);

            // Compile Vertex and Pixel shaders
            var vertexShaderByteCode = ShaderBytecode.CompileFromFile("SSAKLogo.fx", "VS", "vs_4_0");
            var vertexShader = new VertexShader(device, vertexShaderByteCode);

            var pixelShaderByteCode = ShaderBytecode.CompileFromFile("SSAKLogo.fx", "PS", "ps_4_0");
            var pixelShader = new PixelShader(device, pixelShaderByteCode);

            // Layout from VertexShader input signature
            var layout = new InputLayout(device, vertexShaderByteCode, new InputElement[]{
                                        new InputElement("POSITION",0,Format.R32G32B32A32_Float,0,0),
                                        new InputElement("COLOR",0,Format.R32G32B32A32_Float,16,0)
            });

            // Create Constant Buffer
            var contantBuffer = new Buffer(device, Utilities.SizeOf<Matrix>(), ResourceUsage.Default, BindFlags.ConstantBuffer, CpuAccessFlags.None, ResourceOptionFlags.None);
            Triangle t1 = new Triangle(device,new Vector3(1.0f, 0.4f, 0.0f), new Vector2(1, 0), new Vector2(2, 0), new Vector2(1, 1));
            CutTriangle ct1 = new CutTriangle(device, new Vector2[] { new Vector2(0.7f, -0.3f), new Vector2(0.7f, 1.3f), new Vector2(0.9f, 1.1f), new Vector2(0.9f, -0.1f), new Vector2(2.1f, -0.1f), new Vector2(2.3f, -0.3f) });
            Triangle t2 = new Triangle(device, new Vector3(1.0f, 0.4f, 0.0f), new Vector2(0.2f, -0.8f), new Vector2(1.3f, -0.8f), new Vector2(0.75f, -0.3f));
            CutTriangle ct2 = new CutTriangle(device, new Vector2[] { new Vector2(0.1f, -0.9f), new Vector2(1.4f, -0.9f), new Vector2(1.9f, -1.4f), new Vector2(-0.4f, -1.4f) });
            DoubleS ss = new DoubleS(device, new Vector3(1.0f, 0.4f, 0.0f));
            DoubleS ss1 = new DoubleS(device, new Vector3(0.2f, 0.2f, 0.2f));

            var depthBuffer = new Texture2D(device, new Texture2DDescription()
                    {
                        Format = Format.D32_Float_S8X24_UInt,
                        ArraySize = 1,
                        MipLevels = 1,
                        Width = form.ClientSize.Width,
                        Height = form.ClientSize.Height,
                        SampleDescription = new SampleDescription(1, 0),
                        Usage = ResourceUsage.Default,
                        BindFlags = BindFlags.DepthStencil,
                        CpuAccessFlags = CpuAccessFlags.None,
                        OptionFlags = ResourceOptionFlags.None
                    });

            var depthView = new DepthStencilView(device, depthBuffer);

            // Prepare All the stages
            context.InputAssembler.InputLayout = layout;
            context.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            context.VertexShader.SetConstantBuffer(0, contantBuffer);
            context.VertexShader.Set(vertexShader);
            context.Rasterizer.SetViewports(new Viewport(0, 0, form.ClientSize.Width, form.ClientSize.Height, 0.0f, 1.0f));
            context.PixelShader.Set(pixelShader);

            // prid

            var rasterDesc = new RasterizerStateDescription()
            {
                IsAntialiasedLineEnabled = true,
                CullMode = CullMode.Front,
                DepthBias = 0,
                DepthBiasClamp = .0f,
                IsDepthClipEnabled = true,
                FillMode = FillMode.Solid,
                IsFrontCounterClockwise = false,
                IsMultisampleEnabled = false,
                IsScissorEnabled = false,
                SlopeScaledDepthBias = 0.0f
            };
            device.Rasterizer.State = new RasterizerState(device, rasterDesc);
            device.Rasterizer.SetViewports(new Viewport(0, 0, form.ClientSize.Width, form.ClientSize.Height, 0, 1));

            // Prepare matrices
            Matrix view = Matrix.LookAtLH(new Vector3(0.5f, 0.5f, -8), new Vector3(0.5f, 0.5f, 0), Vector3.UnitY);
            Matrix proj = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, form.ClientSize.Width / (float)form.ClientSize.Height, 0.1f, 40f);
            Matrix viewProj = Matrix.Multiply(view, proj);

            t1.ViewProjection = viewProj;
            t2.ViewProjection = viewProj;
            ct1.ViewProjection = viewProj;
            ct2.ViewProjection = viewProj;
            ss.ViewProjection = viewProj;
            ss1.ViewProjection = viewProj;
            var clock = new Stopwatch();
            //clock.Start();
            TimeSpan last = DateTime.Now.TimeOfDay;
            TimeSpan last2 = DateTime.Now.TimeOfDay;
            int fps = 0;
            int deg = 0;

            float y_rot = 0;
            float x_rot = 0;
            float z_rot = 0;
            bool left_stisknuta = false;
            bool right_stisknuta = false;
            bool up_stisknuta = false;
            bool down_stisknuta = false;
            bool z_stisknuta = false;
            bool x_stisknuta = false;



            form.KeyDown += (sender, state) =>
            {
                left_stisknuta = (state.KeyCode == Keys.Left);
                right_stisknuta = (state.KeyCode == Keys.Right);
                up_stisknuta = (state.KeyCode == Keys.Up);
                down_stisknuta = (state.KeyCode == Keys.Down);
                z_stisknuta = (state.KeyCode == Keys.Z);
                x_stisknuta = (state.KeyCode == Keys.X);
            };
            form.KeyUp += (sender, state) =>
            {
                left_stisknuta = (state.KeyCode == Keys.Left);
                right_stisknuta = (state.KeyCode == Keys.Right);
                up_stisknuta = (state.KeyCode == Keys.Up);
                down_stisknuta = (state.KeyCode == Keys.Down);
                z_stisknuta = (state.KeyCode == Keys.Z);
                x_stisknuta = (state.KeyCode == Keys.X);
            };
            RenderLoop.Run(form, () =>
                {
                    // Clear views
                    context.OutputMerger.SetTargets(depthView, renderView);

                    context.ClearDepthStencilView(depthView, DepthStencilClearFlags.Depth, 1.0f, 0);
                    context.ClearRenderTargetView(renderView, Colors.Black);

                    // Update WorldViewProj Matrix

                    var worldViewProj = Matrix.Translation(0, 0, -0.125f) * Matrix.RotationX(0) * Matrix.RotationY(0) * Matrix.Translation(new Vector3(0, 0, 0)) * viewProj;
                    worldViewProj.Transpose();
                    context.UpdateSubresource(ref worldViewProj, contantBuffer);

                    t2.Draw(device);
                    t1.Draw(device);
                    ct1.Draw(device);
                    ct2.Draw(device);
                    fps++;

                    if ((DateTime.Now.TimeOfDay - last).Seconds > 1)
                    {
                        last = DateTime.Now.TimeOfDay;
                        form.Text = fps.ToString();
                        fps = 0;
                    }
                    if (left_stisknuta)
                        y_rot += 0.01f;
                    if (right_stisknuta)
                        y_rot -= 0.01f;
                    if (up_stisknuta)
                        x_rot += 0.1f;
                    if (down_stisknuta)
                        x_rot -= 0.1f;
                    if (z_stisknuta)
                        z_rot += 0.01f;
                    if (x_stisknuta)
                        z_rot -= 0.01f;
                    if ((DateTime.Now.TimeOfDay - last2).Milliseconds > 20)
                    {
                        last2 = DateTime.Now.TimeOfDay;
                        deg++;
                        if (deg == 360) deg = 0;
                    }
                    var time = clock.ElapsedMilliseconds / 1000.0f;

                    t1.rotation = Matrix.Translation(-1, 0, 0) * Matrix.Scaling(2 + (float)Math.Sin((float)(deg / (float)Math.PI))) * Matrix.Translation(1f, 0, 0);

                    t2.SetAxis(-0.75f, t2.axis.Y, t2.axis.Z);
                    t2.rotation = Matrix.RotationAxis(new Vector3(0, 1f, 0), MathUtil.DegreesToRadians(x_rot));
                    
                    ss.SetAxis(0.19f, 0, t2.axis.Z);
                    ss.rotation = Matrix.RotationY(MathUtil.DegreesToRadians(deg)) * Matrix.RotationZ(MathUtil.DegreesToRadians(45));
                    ss.position = new Vector3(-0.9f, -0.4f, 0);
                    ss.Draw(device);

                    ss1.SetAxis(0.19f, 0, t2.axis.Z);
                    ss1.rotation = Matrix.RotationY(MathUtil.DegreesToRadians(deg)) * Matrix.RotationZ(MathUtil.DegreesToRadians(45));
                   
                    ss1.position = new Vector3(-0.3f, 0.2f, 0);
                    ss1.Draw(device);
                    // Present!
                    swapChain.Present(0, PresentFlags.None);
                });

            // Release all resources
            vertexShaderByteCode.Dispose();
            vertexShader.Dispose();
            pixelShaderByteCode.Dispose();
            pixelShader.Dispose();
            layout.Dispose();
            renderView.Dispose();
            backBuffer.Dispose();
            context.ClearState();
            context.Flush();
            device.Dispose();
            context.Dispose();
            swapChain.Dispose();
            factory.Dispose();
        }
    }
}