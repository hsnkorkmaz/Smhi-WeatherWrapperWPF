using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
{
    public class Position
    {
        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
