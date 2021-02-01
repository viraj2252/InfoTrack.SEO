using InfoTrack.SEO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.Core.Entities
{
    public class SearchOccurrence
    {
        public string URL { get; set; }
        public int[] Occurrences { get; set; }
        public SearchEngine SearchEngine { get; set; }

        public static SearchOccurrence Create(string url, int[] occurrences)
        {
            var searchOccurrence = new SearchOccurrence
            {
                URL = url,
                Occurrences = occurrences
            };
            return searchOccurrence;
        }
    }
}
