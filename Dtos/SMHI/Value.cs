using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Dtos.SMHI
{
    public class Value
    {
        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("value")]
        public string? Values { get; set; }

        [JsonProperty("quality")]
        public string? Quality { get; set; }
    }
}
