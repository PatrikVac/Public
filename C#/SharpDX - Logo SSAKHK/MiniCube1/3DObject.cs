using System;
using System.Collections.Generic;
using System.Text;
using SharpDX;

namespace SSAKLogo
{
    class _3DObject
    {
        public Matrix rotation = Matrix.Identity;
        public Vector3 position;
        public Vector3 axis;
        public Matrix scale = Matrix.Scaling(1, 1, 1);
        public Matrix ViewProjection = Matrix.Identity;

        public void SetAxis(float X, float Y, float Z)
        {
            if (X != 0)
            {
                this.axis.X = X;
                this.position.X = -X;
            }
            if (Y != 0)
            {
                this.position.Y = Y;
                this.axis.Y = Y;
            }
            if (Z != 0)
            {
                this.position.Z = Z;
                this.axis.Z = Z;
            }
        }
    }
}
