using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Dtos.SMHI
{
    public class Link
    {
        [JsonProperty("rel")]
        public string? Rel { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("href")]
        public string? Href { get; set; }
    }
}
