using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Dtos.SMHI
{
    public class Parameter
    {
        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("unit")]
        public string? Unit { get; set; }
    }
}
