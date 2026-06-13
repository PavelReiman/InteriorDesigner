using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InteriorDesigner.Models
{
    public class Room
    {
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public Room()
        {
            Width = 8;
            Height = 3;
            Length = 8;
        }

        [Category("Цвет пола")]
        public float FloorR { get; set; } = 0.55f;

        [Category("Цвет пола")]
        public float FloorG { get; set; } = 0.42f;

        [Category("Цвет пола")]
        public float FloorB { get; set; } = 0.25f;

        [Category("Цвет потолка")]
        public float CeilingR { get; set; } = 0.9f;

        [Category("Цвет потолка")]
        public float CeilingG { get; set; } = 0.9f;

        [Category("Цвет потолка")]
        public float CeilingB { get; set; } = 0.9f;

        [Category("Левая стена")]
        public float LeftWallR { get; set; } = 0.95f;

        [Category("Левая стена")]
        public float LeftWallG { get; set; } = 0.95f;

        [Category("Левая стена")]
        public float LeftWallB { get; set; } = 0.95f;

        [Category("Правая стена")]
        public float RightWallR { get; set; } = 0.95f;

        [Category("Правая стена")]
        public float RightWallG { get; set; } = 0.95f;

        [Category("Правая стена")]
        public float RightWallB { get; set; } = 0.95f;

        [Category("Передняя стена")]
        public float FrontWallR { get; set; } = 0.95f;

        [Category("Передняя стена")]
        public float FrontWallG { get; set; } = 0.95f;

        [Category("Передняя стена")]
        public float FrontWallB { get; set; } = 0.95f;

        [Category("Задняя стена")]
        public float BackWallR { get; set; } = 0.95f;

        [Category("Задняя стена")]
        public float BackWallG { get; set; } = 0.95f;

        [Category("Задняя стена")]
        public float BackWallB { get; set; } = 0.95f;
    }
}
