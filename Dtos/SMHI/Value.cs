using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
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
