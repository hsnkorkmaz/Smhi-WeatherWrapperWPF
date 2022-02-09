using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
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
