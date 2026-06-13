using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InteriorDesigner.Models
{
    public class ProjectData
    {
        public Room? Room { get; set; }
        public List<Furniture> FurnitureList { get; set; }
        public ProjectData()
        {
            Room = null;
            FurnitureList = new List<Furniture>();
        }
    }
}
