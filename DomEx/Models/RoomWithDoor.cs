using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomEx.Models
{
    public class RoomWithDoor : Room, IHasExteriorDoor
    {
        public string DoorDescription { get; set; }
        public Location DoorLocation { get; }

        public RoomWithDoor(string name) : base(name)
        {
        }
    }
}
