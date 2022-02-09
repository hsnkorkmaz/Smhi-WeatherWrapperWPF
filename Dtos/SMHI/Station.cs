using System.Collections.Generic;
using Newtonsoft.Json;

namespace SMHIAPI.Dtos.SMHI
{
    public class Station
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("owner")]
        public string? Owner { get; set; }

        [JsonProperty("ownerCategory")]
        public string? OwnerCategory { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }

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

        [JsonProperty("value")]
        public List<Value>? Value { get; set; }
    }
}
