using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventhclass
    {
        public int Eventclassid { get; set; }
        public int? Eventid { get; set; }
        public int? Classid { get; set; }

        public virtual Hclass Class { get; set; }
        public virtual Event Event { get; set; }
    }
}
