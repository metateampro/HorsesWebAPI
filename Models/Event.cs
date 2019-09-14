using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Event
    {
        public Event()
        {
            Characteristics = new HashSet<Characteristics>();
            Evaluate = new HashSet<Evaluate>();
            Hclasses = new HashSet<Hclasses>();
            Horses = new HashSet<Horses>();
        }

        public int Eventid { get; set; }
        public string Title { get; set; }
        public int? Judges { get; set; }
        public DateTime? Eventdate { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Characteristics> Characteristics { get; set; }
        public virtual ICollection<Evaluate> Evaluate { get; set; }
        public virtual ICollection<Hclasses> Hclasses { get; set; }
        public virtual ICollection<Horses> Horses { get; set; }
    }
}
