using InfoTrack.SEO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.SEO.API.Models
{
    public class SearchResponseViewData
    {
        public string URL { get; set; }
        public string Occurrences { get; set; }
        public SearchEngine SearchEngine { get; set; }
    }
}
