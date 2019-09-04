using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Hclass
    {
        public Hclass()
        {
            Eventhclass = new HashSet<Eventhclass>();
            Horse = new HashSet<Horse>();
        }

        public int Classid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Eventhclass> Eventhclass { get; set; }
        public virtual ICollection<Horse> Horse { get; set; }
    }
}
