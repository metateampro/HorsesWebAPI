using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Horse
    {
        public Horse()
        {
            Evaluate = new HashSet<Evaluate>();
            Eventhorse = new HashSet<Eventhorse>();
        }

        public int Horseid { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public int? Hclassid { get; set; }
        public int? Age { get; set; }
        public int? Eventid { get; set; }

        public virtual Event Event { get; set; }
        public virtual Hclass Hclass { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Eventhorse> Eventhorse { get; set; }
    }
}
