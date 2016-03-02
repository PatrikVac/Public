using System.Collections.Generic;
using System.Text;
using Device = SharpDX.Direct3D10.Device;
using Buffer = SharpDX.Direct3D10.Buffer;
using SharpDX;
using SharpDX.Direct3D10;
using SharpDX.Direct3D;

namespace SSAKLogo
{
    class Triangle:_3DObject
    {
        public Buffer vertices;
        public Triangle(Device device,Vector3 c, Vector2 A, Vector2 B, Vector2 C)
        {
            axis = new Vector3(0, 0, -0.125f);
            Vector4 c4 = new Vector4(c, 1);
            Vector4 colorSide = c4; colorSide.Y -= 0.05f;
            Vector3 A1 = new Vector3(A, 0);     //0,0
            Vector3 B1 = new Vector3(B, 0);     //4,0
            Vector3 C1 = new Vector3(C, 0);     //2,2
            Vector3 A2 = new Vector3(A, 0.25f);
            Vector3 B2 = new Vector3(B, 0.25f);
            Vector3 C2 = new Vector3(C, 0.25f);
            vertices = Buffer.Create(device, BindFlags.VertexBuffer, new[]
                                {
                                    // pozice               //barva
                                    new Vector4(A1,1),c4,
                                    new Vector4(B1,1),c4,
                                    new Vector4(C1,1),c4,
                                    new Vector4(C2,1),c4,
                                    new Vector4(A1,1),c4,
                                    new Vector4(A2,1),c4,
                                    new Vector4(B1,1),c4,
                                    new Vector4(B2,1),c4,
                                    new Vector4(C2,1),c4,
                                     new Vector4(A2,1),c4,
                                });
        }

        public void Draw(Device device)
        {
            device.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleStrip;
            device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertices, Utilities.SizeOf<Vector4>() * 2, 0));
            var worldViewProj = Matrix.Translation(this.axis) * this.rotation * Matrix.Translation(this.position) * this.scale *ViewProjection;
            worldViewProj.Transpose();
            Buffer constantBuffer = device.VertexShader.GetConstantBuffers(0, 1)[0];
            device.UpdateSubresource(ref worldViewProj, constantBuffer);

            device.Draw(10, 0);
        }
    }
}
