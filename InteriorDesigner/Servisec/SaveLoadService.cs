using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using OpenTK.Mathematics;
using InteriorDesigner.Models;

namespace InteriorDesigner.Servisec
{
    public static class SaveLoadService
    {
        public static void Save(ProjectData project, string fileName)
        {
            ProjectSaveData data = new();
            data.Room = new RoomSaveData
            {
                Width = project.Room.Width,
                Height = project.Room.Height,
                Length = project.Room.Length,

                FloorR = project.Room.FloorR,
                FloorG = project.Room.FloorG,
                FloorB = project.Room.FloorB,

                CeilingR = project.Room.CeilingR,
                CeilingG = project.Room.CeilingG,
                CeilingB = project.Room.CeilingB,

                LeftWallR = project.Room.LeftWallR,
                LeftWallG = project.Room.LeftWallG,
                LeftWallB = project.Room.LeftWallB,

                RightWallR = project.Room.RightWallR,
                RightWallG = project.Room.RightWallG,
                RightWallB = project.Room.RightWallB,

                FrontWallR = project.Room.FrontWallR,
                FrontWallG = project.Room.FrontWallG,
                FrontWallB = project.Room.FrontWallB,

                BackWallR = project.Room.BackWallR,
                BackWallG = project.Room.BackWallG,
                BackWallB = project.Room.BackWallB
            };
            foreach(var item in project.FurnitureList)
            {
                data.Furniture.Add(new FurnitureSaveData
                {
                    Id = item.Id,
                    Name = item.Name,
                    ModelPath = item.ModelPath,

                    PositionX = item.PositionX,
                    PositionY = item.PositionY,
                    PositionZ = item.PositionZ,

                    RotationX = item.RotationX,
                    RotationY = item.RotationY,
                    RotationZ = item.RotationZ,

                    ScaleX = item.ScaleX,
                    ScaleY = item.ScaleY,
                    ScaleZ = item.ScaleZ,

                    ColorR = item.ColorR,
                    ColorG = item.ColorG,
                    ColorB = item.ColorB,
                });
            }
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(fileName, json);
        }

        public static ProjectData Load(string fileName)
        {
            string json = File.ReadAllText(fileName);
            ProjectSaveData data = JsonSerializer.Deserialize<ProjectSaveData>(json);

            ProjectData project = new();

            project.Room = new Room
            {
                Width = data.Room.Width,
                Height = data.Room.Height,
                Length = data.Room.Length,

                FloorR = data.Room.FloorR,
                FloorG = data.Room.FloorG,
                FloorB = data.Room.FloorB,

                CeilingR = data.Room.CeilingR,
                CeilingG = data.Room.CeilingG,
                CeilingB = data.Room.CeilingB,

                LeftWallR = data.Room.LeftWallR,
                LeftWallG = data.Room.LeftWallG,
                LeftWallB = data.Room.LeftWallB,

                RightWallR = data.Room.RightWallR,
                RightWallG = data.Room.RightWallG,
                RightWallB = data.Room.RightWallB,

                FrontWallR = data.Room.FrontWallR,
                FrontWallG = data.Room.FrontWallG,
                FrontWallB = data.Room.FrontWallB,

                BackWallR = data.Room.BackWallR,
                BackWallG = data.Room.BackWallG,
                BackWallB = data.Room.BackWallB
            };
            foreach (var item in data.Furniture)
            {
                project.FurnitureList.Add(new Furniture
                {
                    Id = item.Id,
                    Name = item.Name,
                    ModelPath = item.ModelPath,

                    PositionX = item.PositionX,
                    PositionY = item.PositionY,
                    PositionZ = item.PositionZ,

                    RotationX = item.RotationX,
                    RotationY = item.RotationY,
                    RotationZ = item.RotationZ,

                    ScaleX = item.ScaleX,
                    ScaleY = item.ScaleY,
                    ScaleZ = item.ScaleZ,

                    ColorR = item.ColorR,
                    ColorG = item.ColorG,
                    ColorB = item.ColorB,
                });
            }
            return project;
        }
    }
}
