using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventhclass
    {
        public int Eventclassid { get; set; }
        public int? Eventid { get; set; }
        public int? Hclassid { get; set; }

        public virtual Event Event { get; set; }
        public virtual Hclass Hclass { get; set; }
    }
}
