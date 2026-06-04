using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using System.Globalization;

namespace InteriorDesigner.Models
{
    public class ObjModel
    {
        public List<Vector3> Vertices { get; set; } = new();
        public List<int> Indices { get; set; } = new();
        public float RecommendedScale { get; set; } = 1f;
    }
}
