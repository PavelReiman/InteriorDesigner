using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using InteriorDesigner.Models;

namespace InteriorDesigner.Graphics
{
    public class ObjMesh
    {
        private int vao;
        private int vbo;
        private int ebo;

        private int indexCount;

        public ObjMesh(ObjModel model)
        {
            float[] vertices = new float[model.Vertices.Count * 3];
            for (int i=0; i<model.Vertices.Count; i++)
            {
                vertices[i * 3] = model.Vertices[i].X;
                vertices[i * 3 + 1] = model.Vertices[i].Y;
                vertices[i * 3 + 2] = model.Vertices[i].Z;
            }
            vao = GL.GenVertexArray();
            vbo = GL.GenBuffer();
            ebo = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, model.Indices.Count * sizeof(int), model.Indices.ToArray(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            GL.BindVertexArray(0);

            indexCount = model.Indices.Count;
        }

        public void Draw()
        {
            GL.BindVertexArray(vao);
            GL.DrawElements(PrimitiveType.Triangles, indexCount, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
        }
    }
}
