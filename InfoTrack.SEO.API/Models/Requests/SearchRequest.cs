using InfoTrack.SEO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoTrack.SEO.API.Models.Requests
{
    public class SearchRequest
    {
        public string Keywords { get; set; }
        public string URL { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SearchEngine SearchEngine { get; set; }
    }
}
