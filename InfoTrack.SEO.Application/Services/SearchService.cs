using InfoTrack.SEO.Application.Helpers;
using InfoTrack.SEO.Application.Interfaces;
using InfoTrack.SEO.Application.Models;
using InfoTrack.SEO.Core.Entities;
using InfoTrack.SEO.Core.Enums;
using InfoTrack.SEO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Application.Services
{
    public class SearchService : ISearchService
    {
        private WebScrapper _webScrapper;
        private readonly IAppLogger<SearchService> _logger;

        public SearchService(IAppLogger<SearchService> logger)
        {
            _webScrapper = new WebScrapper();
            _logger = logger;
        }
        public async Task<SearchOccurrence> Search(string keywords, Uri url, SearchEngine searchEngine)
        {
            _logger.LogInformation("Calling Search method");
            var scrapeResults = await _webScrapper.GetMatchingURLs(keywords, searchEngine, url);
            var result = new SearchOccurrence
            {
                Occurrences = scrapeResults.Any() ? scrapeResults.Select(s => s.Index).ToArray() : new int[] { 0 },
                SearchEngine = searchEngine,
                URL = url.ToString()
            };

            return result;
        }
    }
}
