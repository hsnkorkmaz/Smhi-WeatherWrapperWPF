using System.Collections.Generic;
using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI.Main
{
    //https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1.json
    public class StationResult
    {
        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("owner")]
        public string? Owner { get; set; }

        [JsonProperty("ownerCategory")]
        public string? OwnerCategory { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("position")]
        public List<Position>? Position { get; set; }

        [JsonProperty("link")]
        public List<Link>? Link { get; set; }

        [JsonProperty("period")]
        public List<Period>? Period { get; set; }
    }


}
