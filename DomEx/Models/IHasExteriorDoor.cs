using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomEx.Models
{
    public interface IHasExteriorDoor
    {
        string DoorDescription { get; set; }
        Location DoorLocation { get; set; }

    }
}
