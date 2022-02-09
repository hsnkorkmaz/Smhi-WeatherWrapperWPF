using System.Collections.Generic;
using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI.Main
{
    //https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station/159880/period/latest-months.json
    //https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station-set/all/period/latest-hour.json

    public class PeriodResult
    {
        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("link")]
        public List<Link>? Link { get; set; }

        [JsonProperty("data")]
        public List<Data>? Data { get; set; }
    }


}
