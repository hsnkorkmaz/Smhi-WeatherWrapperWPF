﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Dtos.SMHI.Main
{
    //https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1.json

    public class ParameterResult
    {
        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("summary")]
        public string? Summary { get; set; }

        [JsonProperty("valueType")]
        public string? ValueType { get; set; }

        [JsonProperty("link")]
        public List<Link>? Link { get; set; }

        [JsonProperty("stationSet")]
        public List<StationSet>? StationSet { get; set; }

        [JsonProperty("station")]
        public List<Station>? Station { get; set; }
    }
}