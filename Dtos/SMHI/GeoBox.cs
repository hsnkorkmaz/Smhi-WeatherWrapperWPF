using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Dtos.SMHI
{
    public class GeoBox
    {
        [JsonProperty("minLatitude")]
        public int MinLatitude { get; set; }

        [JsonProperty("minLongitude")]
        public int MinLongitude { get; set; }

        [JsonProperty("maxLatitude")]
        public int MaxLatitude { get; set; }

        [JsonProperty("maxLongitude")]
        public int MaxLongitude { get; set; }
    }
}
