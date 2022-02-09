using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
{
    public class GeoBox
    {
        [JsonProperty("minLatitude")]
        public int MinLatitude { get; set; }

        [JsonProperty("minLongitude")]
        public int MinLongitude { get; set; }

        [JsonProperty("maxLatitude")]
        public int MaxLatitude { get; set; }

        [JsonProperty("maxLongitude")]
        public int MaxLongitude { get; set; }
    }
}
