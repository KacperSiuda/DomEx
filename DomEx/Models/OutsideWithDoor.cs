using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomEx.Models
{
    public class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public string DoorDescription { get; set; }
        public Location DoorLocation { get; set; }


        public OutsideWithDoor(string name, bool hot, string doorDescription) : base(name, hot)
        {
            this.DoorDescription = doorDescription;
        }

        public override string Description
        {
            get { return base.Description + "Widzisz teraz " + DoorDescription + "."; }
        }
    }
}
