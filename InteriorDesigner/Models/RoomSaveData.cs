using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigner.Models
{
    public class RoomSaveData
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }

        public float FloorR { get; set; }
        public float FloorG { get; set; }
        public float FloorB { get; set; }

        public float CeilingR { get; set; }
        public float CeilingG { get; set; }
        public float CeilingB { get; set; }

        public float LeftWallR { get; set; }
        public float LeftWallG { get; set; }
        public float LeftWallB { get; set; }

        public float RightWallR { get; set; }
        public float RightWallG { get; set; }
        public float RightWallB { get; set; }

        public float FrontWallR { get; set; }
        public float FrontWallG { get; set; }
        public float FrontWallB { get; set; }

        public float BackWallR { get; set; }
        public float BackWallG { get; set; }
        public float BackWallB { get; set; }
    }
}
