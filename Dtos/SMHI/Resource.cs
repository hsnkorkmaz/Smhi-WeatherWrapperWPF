using System.Collections.Generic;
using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
{
    public class Resource
    {
        [JsonProperty("geoBox")]
        public GeoBox? GeoBox { get; set; }

        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("link")]
        public List<Link>? Link { get; set; }
    }
}
