using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigner.Models
{
    public class SerializableVector3
    {
        public float X {  get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public SerializableVector3()
        {

        }
        public SerializableVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
