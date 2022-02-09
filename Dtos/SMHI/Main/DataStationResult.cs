using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Dtos.SMHI.Main
{
    public class DataStationResult
    {
        [JsonProperty("value")]
        public List<Value>? Value { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("parameter")]
        public Parameter? Parameter { get; set; }

        [JsonProperty("station")]
        public Station? Station { get; set; }

        [JsonProperty("period")]
        public Period? Period { get; set; }

        [JsonProperty("position")]
        public List<Position>? Position { get; set; }

        [JsonProperty("link")]
        public List<Link>? Link { get; set; }
    }
}
