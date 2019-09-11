using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Characteristic
    {
        public Characteristic()
        {
            Evaluate = new HashSet<Evaluate>();
            Eventcharacteristic = new HashSet<Eventcharacteristic>();
        }

        public int Characteristicid { get; set; }
        public string Title { get; set; }
        public int? Eventid { get; set; }

        public virtual Event Event { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Eventcharacteristic> Eventcharacteristic { get; set; }
    }
}
