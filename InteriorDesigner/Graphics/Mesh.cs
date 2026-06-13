using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace InteriorDesigner.Graphics
{
    public class Mesh
    {
        public int VAO;
        public int VBO;
        public int VertexCount;

        public Mesh(float[] vertices)
        {
            VertexCount = vertices.Length / 3;

            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);

            GL.BufferData(
                BufferTarget.ArrayBuffer,
                vertices.Length * sizeof(float),
                vertices,
                BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(
                0,
                3,
                VertexAttribPointerType.Float,
                false,
                3 * sizeof(float),
                0);

            GL.EnableVertexAttribArray(0);

            GL.BindVertexArray(0);
        }

        public void Draw()
        {
            GL.BindVertexArray(VAO);

            GL.DrawArrays(
                PrimitiveType.Triangles,
                0,
                VertexCount);

            GL.BindVertexArray(0);
        }
    }
}
