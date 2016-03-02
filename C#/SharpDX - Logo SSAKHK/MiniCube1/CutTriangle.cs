using System;
using System.Collections.Generic;
using System.Text;
using Device = SharpDX.Direct3D10.Device;
using Buffer = SharpDX.Direct3D10.Buffer;
using SharpDX;
using SharpDX.Direct3D10;
using SharpDX.Direct3D;

namespace SSAKLogo
{
    class CutTriangle:_3DObject
    {
        Buffer vertices;
        int count = 0;
        public CutTriangle(Device device, params Vector2[] vektor)
        {
            count = vektor.Length;
            var data =new List<Vector4>();
            for (int i = 0; i < vektor.Length-1; i++)
            {
                data.Add(new Vector4(new Vector3(vektor[0], 0), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));

                data.Add(new Vector4(new Vector3(vektor[i], 0.25f), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[0], 0.25f), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));


                data.Add(new Vector4(new Vector3(vektor[i], 0.25f), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));


                data.Add(new Vector4(new Vector3(vektor[i + 1], 0.25f), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i], 0), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                data.Add(new Vector4(new Vector3(vektor[i + 1], 0), 1));
                data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
                

            }
            data.Add(new Vector4(new Vector3(vektor[vektor.Length-1], 0.25f), 1));
            data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Length - 1], 0), 1));
            data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
            data.Add(new Vector4(new Vector3(vektor[0], 0.25f), 1));
            data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));


            data.Add(new Vector4(new Vector3(vektor[0], 0.25f), 1));
            data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
            data.Add(new Vector4(new Vector3(vektor[vektor.Length - 1], 0), 1));
            data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));
            data.Add(new Vector4(new Vector3(vektor[0], 0), 1));
            data.Add(new Vector4(0.2f, 0.2f, 0.2f, 1));

            count = data.Count/2;
            vertices = Buffer.Create(device, BindFlags.VertexBuffer, data.ToArray());
        }

        public void Draw(Device device)
        {
            device.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            device.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertices, Utilities.SizeOf<Vector4>() * 2, 0));

            var worldViewProj = Matrix.Translation(0, 0, -0.125f) * this.rotation * Matrix.Translation(this.position) * ViewProjection;
            worldViewProj.Transpose();
            Buffer constantBuffer = device.VertexShader.GetConstantBuffers(0, 1)[0];
            device.UpdateSubresource(ref worldViewProj, constantBuffer);

            device.Draw(count, 0);
        }
    }
}
