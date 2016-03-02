using System;
using System.Collections.Generic;
using System.Text;
using Device = SharpDX.Direct3D10.Device;
using Buffer = SharpDX.Direct3D10.Buffer;
using SharpDX;
using SharpDX.Direct3D10;
using SharpDX.Direct3D;
using System.Windows.Forms;

namespace SSAKLogo
{
    class DoubleS:_3DObject
    {
        Buffer vertices;
        int count = 0;
        public DoubleS(Device device, Vector3 color)
        {
            axis = new Vector3(0, 0, -0.125f);
            Vector3 colorSide = color; colorSide.Y -= 0.05f;
            var vektor = new List<Vector2>();
            for (float y = -1; y < 1; y += 0.1f)
            {
                float x = ((y + 0.8f) * y * (y - 0.8f) + 0.7f) / 2;
                vektor.Add(new Vector2(x, y));
            }
            for (float y = -1; y < 1; y += 0.1f)
            {
                float x = ((y + 0.8f) * y * (y - 0.8f) - 0.7f) / 2;
                vektor.Add(new Vector2(x, y));
            }
            count = vektor.Count;
            var data = new List<Vector4>();
            for (int i = 0; i < vektor.Count / 2 - 1; i++)
            {
                // predni stena
                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));//A
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0), 1));//B
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 + i], 0), 1));//C
                data.Add(new Vector4(color, 1));

                data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 + i], 0), 1)); //C
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3((vektor[i + 1]), 0), 1));//B
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 + i + 1], 0), 1));//D
                data.Add(new Vector4(color, 1));

                // zadni stena
                data.Add(new Vector4(new Vector3(vektor[i], 0.25f), 1));
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3((vektor[vektor.Count / 2 + i]), 0.25f), 1));
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(color, 1));

                data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 + i], 0.25f), 1));
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 + i + 1], 0.25f), 1));
                data.Add(new Vector4(color, 1));
                data.Add(new Vector4(new Vector3((vektor[i + 1]), 0.25f), 1));
                data.Add(new Vector4(color, 1));
            }
            for (int i = 0; i < vektor.Count / 2 - 1; i++) // pravej bok
            {
                data.Add(new Vector4(new Vector3(vektor[i], 0.25f), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(colorSide, 1));


                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0), 1));
                data.Add(new Vector4(colorSide, 1));


            }
            for (int i = vektor.Count / 2; i < vektor.Count - 1; i++) // levej bok
            {
                data.Add(new Vector4(new Vector3(vektor[i], 0.25f), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(colorSide, 1));


                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0), 1));
                data.Add(new Vector4(colorSide, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(colorSide, 1));


            }

            data.Add(new Vector4(new Vector3(vektor[0], 0.25f), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[0], 0), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2], 0.25f), 1));
            data.Add(new Vector4(color, 1));

            data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2], 0.25f), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[0], 0), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2], 0), 1));
            data.Add(new Vector4(color, 1));

            data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 - 1], 0.25f), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Count - 1], 0.25f), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 - 1], 0), 1));
            data.Add(new Vector4(color, 1));


            data.Add(new Vector4(new Vector3(vektor[vektor.Count / 2 - 1], 0), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Count - 1], 0.25f), 1));
            data.Add(new Vector4(color, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Count - 1], 0), 1));
            data.Add(new Vector4(color, 1));

            count = data.Count / 2;
            vertices = Buffer.Create(device, BindFlags.VertexBuffer, data.ToArray());


        }
        public void Draw(Device device)
        {
            device.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertices, Utilities.SizeOf<Vector4>() * 2, 0));

            var worldViewProj = Matrix.Translation(this.axis) * this.rotation * Matrix.Translation(this.position) * ViewProjection;
            worldViewProj.Transpose();
            Buffer constantBuffer = device.VertexShader.GetConstantBuffers(0, 1)[0];
            device.UpdateSubresource(ref worldViewProj, constantBuffer);

            device.Draw(count, 0);
        }
    }
}
