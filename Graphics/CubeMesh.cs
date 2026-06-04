using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigner.Graphics
{
    public static class CubeMesh
    {
        public static float[] Vertices =
        {
            // Передняя грань
            -0.5f,-0.5f, 0.5f,
             0.5f,-0.5f, 0.5f,
             0.5f, 0.5f, 0.5f,

             0.5f, 0.5f, 0.5f,
            -0.5f, 0.5f, 0.5f,
            -0.5f,-0.5f, 0.5f,

            // Задняя грань
            -0.5f,-0.5f,-0.5f,
             0.5f, 0.5f,-0.5f,
             0.5f,-0.5f,-0.5f,

             0.5f, 0.5f,-0.5f,
            -0.5f,-0.5f,-0.5f,
            -0.5f, 0.5f,-0.5f,

            // Левая грань
            -0.5f,-0.5f,-0.5f,
            -0.5f,-0.5f, 0.5f,
            -0.5f, 0.5f, 0.5f,

            -0.5f, 0.5f, 0.5f,
            -0.5f, 0.5f,-0.5f,
            -0.5f,-0.5f,-0.5f,

            // Правая грань
             0.5f,-0.5f,-0.5f,
             0.5f, 0.5f, 0.5f,
             0.5f,-0.5f, 0.5f,

             0.5f, 0.5f,-0.5f,
             0.5f, 0.5f, 0.5f,
             0.5f,-0.5f,-0.5f,

            // Верх
            -0.5f, 0.5f,-0.5f,
            -0.5f, 0.5f, 0.5f,
             0.5f, 0.5f, 0.5f,

             0.5f, 0.5f, 0.5f,
             0.5f, 0.5f,-0.5f,
            -0.5f, 0.5f,-0.5f,

            // Низ
            -0.5f,-0.5f,-0.5f,
             0.5f,-0.5f, 0.5f,
            -0.5f,-0.5f, 0.5f,

             0.5f,-0.5f,-0.5f,
             0.5f,-0.5f, 0.5f,
            -0.5f,-0.5f,-0.5f
        };
    }
}
