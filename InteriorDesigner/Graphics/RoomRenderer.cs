using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace InteriorDesigner.Graphics
{
    public static class RoomRenderer
    {
        public static void DrawFloor(float width, float length)
        {
            float w = width / 2f;
            float l = length / 2f;

            float[] vertices = {
                -w,0, -l,
                 w, 0, -l,

                 w,0,-l,
                 w,0,l,

                 w,0,l,
                 -w,0,l,

                 -w,0,l,
                 -w,0,-l
            };

            int vao = GL.GenVertexArray();
            int vbo = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3* sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.DrawArrays(PrimitiveType.Lines, 0, 8);

            GL.DeleteBuffer(vbo);
            GL.DeleteVertexArray(vao);
        }
    }
}
