using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventhclass
    {
        public int Eventid { get; set; }
        public int Hclassid { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual Hclass Hclass { get; set; }
    }
}
