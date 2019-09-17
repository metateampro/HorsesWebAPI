using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HorsesWebAPI.Models
{
    public partial class Eventhorse
    {
        public int Eventid { get; set; }
        public int Horseid { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [JsonIgnore]
        public virtual Horse Horse { get; set; }
    }
}
