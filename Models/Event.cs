using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Event
    {
        public Event()
        {
            Characteristic = new HashSet<Characteristic>();
            Evaluate = new HashSet<Evaluate>();
            Eventcharacteristic = new HashSet<Eventcharacteristic>();
            Eventhclass = new HashSet<Eventhclass>();
            Eventhorse = new HashSet<Eventhorse>();
            Hclass = new HashSet<Hclass>();
            Horse = new HashSet<Horse>();
        }

        public int Eventid { get; set; }
        public string Title { get; set; }
        public int? Judges { get; set; }
        public DateTime? Eventdate { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Characteristic> Characteristic { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Eventcharacteristic> Eventcharacteristic { get; set; }
        public virtual ICollection<Eventhclass> Eventhclass { get; set; }
        public virtual ICollection<Eventhorse> Eventhorse { get; set; }
        public virtual ICollection<Hclass> Hclass { get; set; }
        public virtual ICollection<Horse> Horse { get; set; }
    }
}
