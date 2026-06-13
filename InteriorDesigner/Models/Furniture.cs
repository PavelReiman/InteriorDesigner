using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using System.ComponentModel;

namespace InteriorDesigner.Models
{
    public class Furniture
    {
        [Category("Основное")]
        [DisplayName("ID")]
        public int Id { get; set; }

        [Category("Основное")]
        [DisplayName("Название")]
        public string Name { get; set; } = "";

        [Category("Основное")]
        [DisplayName("Путь к модели")]
        public string ModelPath { get; set; } = "";

        [Category("Материал")]
        [DisplayName("Тип материала")]
        public MaterialType Material { get; set; } = MaterialType.Wood;

        // Положение

        [Category("Положение")]
        [DisplayName("X")]
        public float PositionX { get; set; }

        [Category("Положение")]
        [DisplayName("Y")]
        public float PositionY { get; set; }

        [Category("Положение")]
        [DisplayName("Z")]
        public float PositionZ { get; set; }

        // Вращение

        [Category("Вращение")]
        [DisplayName("X")]
        public float RotationX { get; set; }

        [Category("Вращение")]
        [DisplayName("Y")]
        public float RotationY { get; set; }

        [Category("Вращение")]
        [DisplayName("Z")]
        public float RotationZ { get; set; }

        // Масштаб

        [Category("Масштаб")]
        [DisplayName("X")]
        public float ScaleX { get; set; } = 1f;

        [Category("Масштаб")]
        [DisplayName("Y")]
        public float ScaleY { get; set; } = 1f;

        [Category("Масштаб")]
        [DisplayName("Z")]
        public float ScaleZ { get; set; } = 1f;

        // Цвет

        [Category("Материал")]
        [DisplayName("Красный")]
        public float ColorR { get; set; } = 0.5f;

        [Category("Материал")]
        [DisplayName("Зеленый")]
        public float ColorG { get; set; } = 0.5f;

        [Category("Материал")]
        [DisplayName("Синий")]
        public float ColorB { get; set; } = 0.5f;

        [Browsable(false)]
        public Vector3 Position
        {
            get => new Vector3(
                PositionX,
                PositionY,
                PositionZ);

            set
            {
                PositionX = value.X;
                PositionY = value.Y;
                PositionZ = value.Z;
            }
        }

        [Browsable(false)]
        public Vector3 Rotation
        {
            get => new Vector3(
                RotationX,
                RotationY,
                RotationZ);

            set
            {
                RotationX = value.X;
                RotationY = value.Y;
                RotationZ = value.Z;
            }
        }

        [Browsable(false)]
        public Vector3 Scale
        {
            get => new Vector3(
                ScaleX,
                ScaleY,
                ScaleZ);

            set
            {
                ScaleX = value.X;
                ScaleY = value.Y;
                ScaleZ = value.Z;
            }
        }

        [Browsable(false)]
        public Vector3 Color
        {
            get => new Vector3(
                ColorR,
                ColorG,
                ColorB);

            set
            {
                ColorR = value.X;
                ColorG = value.Y;
                ColorB = value.Z;
            }
        }

        public void ApplyMaterial()
        {
            switch (Material)
            {
                case MaterialType.Wood:

                    ColorR = 0.55f;
                    ColorG = 0.27f;
                    ColorB = 0.07f;
                    break;

                case MaterialType.Metal:

                    ColorR = 0.7f;
                    ColorG = 0.7f;
                    ColorB = 0.7f;
                    break;

                case MaterialType.Glass:

                    ColorR = 0.6f;
                    ColorG = 0.8f;
                    ColorB = 1.0f;
                    break;

                case MaterialType.Plastic:

                    ColorR = 0.2f;
                    ColorG = 0.2f;
                    ColorB = 0.8f;
                    break;

                case MaterialType.Fabric:

                    ColorR = 0.8f;
                    ColorG = 0.4f;
                    ColorB = 0.4f;
                    break;
            }
        }
    }
}
