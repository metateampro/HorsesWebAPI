using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventhorse
    {
        public int Eventhorseid { get; set; }
        public int? Eventid { get; set; }
        public int? Horseid { get; set; }

        public virtual Event Event { get; set; }
        public virtual Horse Horse { get; set; }
    }
}
