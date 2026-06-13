using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteriorDesigner.Models
{
    public class ProjectSaveData
    {
        public RoomSaveData Room { get; set; }
        public List<FurnitureSaveData> Furniture { get; set; } = new();
    }
}
