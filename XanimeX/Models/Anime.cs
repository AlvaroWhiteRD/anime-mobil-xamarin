using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XanimeX.Model
{
    public class Anime
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("issued")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string Issued { get; set; }

        [JsonProperty("estate")]
        public string Estate { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}