using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Event
    {
        public Event()
        {
            Evaluate = new HashSet<Evaluate>();
            Eventcharacteristic = new HashSet<Eventcharacteristic>();
            Eventhclass = new HashSet<Eventhclass>();
            Eventhorse = new HashSet<Eventhorse>();
        }

        public int Eventid { get; set; }
        public string Title { get; set; }
        public int? Judges { get; set; }
        public DateTime? Eventdate { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Eventcharacteristic> Eventcharacteristic { get; set; }
        public virtual ICollection<Eventhclass> Eventhclass { get; set; }
        public virtual ICollection<Eventhorse> Eventhorse { get; set; }
    }
}
