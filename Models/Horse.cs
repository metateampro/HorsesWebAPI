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
        public int? Number { get; set; }
        public string Age { get; set; }
        public int? Classid { get; set; }

        public virtual Hclass Class { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Eventhorse> Eventhorse { get; set; }
    }
}
