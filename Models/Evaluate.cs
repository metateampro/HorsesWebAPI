using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Evaluate
    {
        public int Evaluateid { get; set; }
        public int? Eventid { get; set; }
        public int? Horseid { get; set; }
        public int? Characteristicid { get; set; }
        public int? Judge { get; set; }
        public decimal? Value { get; set; }

        public virtual Characteristic Characteristic { get; set; }
        public virtual Event Event { get; set; }
        public virtual Horse Horse { get; set; }
    }
}
