using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventcharacteristic
    {
        public int Eventid { get; set; }
        public int Characteristicid { get; set; }
        [JsonIgnore]
        public virtual Characteristic Characteristic { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}
