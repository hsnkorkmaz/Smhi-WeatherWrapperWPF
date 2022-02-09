using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
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
