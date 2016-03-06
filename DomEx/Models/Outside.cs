using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomEx.Models
{
    public class Outside : Location
    {
        public bool hot { get; }

        public Outside(string name, bool hot) : base(name)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                string description = base.Description;
                if (hot == true)
                {
                    description = "Tutaj jest za gorąco.";
                }
                return description;
            } 
        }
    }
}
