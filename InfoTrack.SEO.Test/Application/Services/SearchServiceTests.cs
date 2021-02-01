using InfoTrack.SEO.Application.Interfaces;
using InfoTrack.SEO.Application.Models;
using InfoTrack.SEO.Application.Services;
using InfoTrack.SEO.Infrastructure.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Test.Application.Services
{

    [TestClass]
    public class SearchServiceTests
    {
        ISearchService _searchService;

        public SearchServiceTests()
        {
            var mockLogger = new Mock<LoggerFactory>();
            var loggerAdapter = new LoggerAdapter<SearchService>(mockLogger.Object);
            _searchService = new SearchService(loggerAdapter);
        }

        [TestMethod]
        public async Task LinkItem_test()
        {
            var linkItem = new LinkItem
            {
                Href = "http://vj.com",
                Index = 1,
                Text = "test"
            };
            Assert.IsNotNull(linkItem);
            Assert.AreEqual("test", linkItem.Text);
        }

        [TestMethod]
        public async Task Search_invalid_url_should_return_0_occurrence()
        {
            var result = await _searchService.Search("Test", new Uri("http://vj.com"), Core.Enums.SearchEngine.Bing);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Occurrences.Length);
            Assert.AreEqual(0, result.Occurrences[0]);
        }

        [TestMethod]
        public async Task Search_valid_url_should_return_1_occurrence()
        {
            var result = await _searchService.Search("Test", new Uri("https://www.infotrack.com.au"), Core.Enums.SearchEngine.Google);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Occurrences.Length);
            Assert.AreEqual(1, result.Occurrences[0]);
        }
    }
}
