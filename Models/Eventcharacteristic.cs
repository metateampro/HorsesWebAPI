using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventcharacteristic
    {
        public int Eventcharacteristicid { get; set; }
        public int? Eventid { get; set; }
        public int? Characteristicid { get; set; }

        public virtual Characteristic Characteristic { get; set; }
        public virtual Event Event { get; set; }
    }
}
