using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Event
    {
        public Event()
        {
            Characteristics = new HashSet<Characteristic>();
            Evaluate = new HashSet<Evaluate>();
            Eventcharacteristic = new HashSet<Eventcharacteristic>();
            Eventhclass = new HashSet<Eventhclass>();
            Eventhorse = new HashSet<Eventhorse>();
            Hclasses = new HashSet<Hclass>();
            Horses = new HashSet<Horse>();
        }

        public int Eventid { get; set; }
        public string Title { get; set; }
        public int? Judges { get; set; }
        public DateTime? Eventdate { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Eventcharacteristic> Eventcharacteristic { get; set; }
        public virtual ICollection<Eventhclass> Eventhclass { get; set; }
        public virtual ICollection<Eventhorse> Eventhorse { get; set; }
        public virtual ICollection<Hclass> Hclasses { get; set; }
        public virtual ICollection<Horse> Horses { get; set; }
    }
}
