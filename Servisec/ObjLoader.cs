using InteriorDesigner.Models;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InteriorDesigner.Servisec
{
    public static class ObjLoader
    {
        public static ObjModel Load(string path)
        {
            ObjModel model = new ObjModel();
            foreach (var line in File.ReadLines(path))
            {
                if (line.StartsWith("v "))
                {
                    string[] p =line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    model.Vertices.Add(new Vector3(float.Parse(p[1], CultureInfo.InvariantCulture),
                        float.Parse(p[2], CultureInfo.InvariantCulture), float.Parse(p[3], CultureInfo.InvariantCulture)));
                }
                if (line.StartsWith("f "))
                {
                    string[] p = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    List<int> faceIndices = new();

                    for (int i = 1; i < p.Length; i++)
                    {
                        faceIndices.Add(int.Parse(p[i].Split('/')[0]) - 1);
                    }

                    for (int i = 1; i < faceIndices.Count - 1; i++)
                    {
                        model.Indices.Add(faceIndices[0]);
                        model.Indices.Add(faceIndices[i]);
                        model.Indices.Add(faceIndices[i + 1]);
                    }
                }
            }

            if (model.Vertices.Count > 0)
            {
                float minX = model.Vertices[0].X;
                float maxX = model.Vertices[0].X;

                float minY = model.Vertices[0].Y;
                float maxY = model.Vertices[0].Y;

                float minZ = model.Vertices[0].Z;
                float maxZ = model.Vertices[0].Z;

                foreach (var v in model.Vertices)
                {
                    if (v.X < minX) minX = v.X;
                    if (v.X > maxX) maxX = v.X;

                    if (v.Y < minY) minY = v.Y;
                    if (v.Y > maxY) maxY = v.Y;

                    if (v.Z < minZ) minZ = v.Z;
                    if (v.Z > maxZ) maxZ = v.Z;
                }

                float sizeX = maxX - minX;
                float sizeY = maxY - minY;
                float sizeZ = maxZ - minZ;

                float maxSize = Math.Max(sizeX, Math.Max(sizeY, sizeZ));

                if (maxSize > 0)
                {
                    model.RecommendedScale = 2.0f / maxSize;
                }
            }

            return model;
        }
    }
}
