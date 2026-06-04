using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace InteriorDesigner.Graphics
{
    public class Camera
    {
        public Vector3 Position = new Vector3(0, 5, 15);

        public Vector3 Front = -Vector3.UnitZ;

        public Vector3 Up = Vector3.UnitY;

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(Position, Position + Front, Up);
        }

        public Matrix4 GetProjectionMatrix(float aspect)
        {
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), aspect, 0.1f, 100f);
        }
    }
}
