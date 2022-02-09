using System.Collections.Generic;
using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI.Main
{
    //https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station-set/all.json
    
    public class StationSetResult
    {
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

        [JsonProperty("period")]
        public List<Period>? Period { get; set; }
    }


}
