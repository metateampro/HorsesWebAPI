using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Characteristics
    {
        public Characteristics()
        {
            Evaluate = new HashSet<Evaluate>();
        }

        public int Characteristicid { get; set; }
        public string Title { get; set; }
        public int? Eventid { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
    }
}
