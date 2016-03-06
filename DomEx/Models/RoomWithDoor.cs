using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomEx.Models
{
    public class RoomWithDoor : RoomWithHidingPlaces, IHasExteriorDoor
    {


        public string DoorDescription { get; set; }
        public Location DoorLocation { get; set; }

        public RoomWithDoor(string name, string decoration,
            string hidingPlaces, string doorDescription) : base(name, decoration, hidingPlaces)
        {
            this.DoorDescription = doorDescription;
        }
    }
}
