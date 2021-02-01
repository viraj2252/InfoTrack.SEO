using InfoTrack.SEO.Application.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Test.Application
{

    [TestClass]
    public class WebScrapperTests
    {
        [TestMethod]
        public async Task GetMatchingURLs_should_return_null_on_Google_for_vjdotcom()
        {
            WebScrapper ws = new WebScrapper();
            var results = await ws.GetMatchingURLs("test", Core.Enums.SearchEngine.Google, new Uri("https://vj.com"));

            Assert.IsTrue(!results.Any());
        }

        [TestMethod]
        public async Task GetMatchingURLs_should_return_null_on_Bing_for_vjdotcom()
        {
            WebScrapper ws = new WebScrapper();
            var results = await ws.GetMatchingURLs("test", Core.Enums.SearchEngine.Bing, new Uri("https://vj.com"));

            Assert.IsTrue(!results.Any());
        }

        [TestMethod]
        public async Task GetMatchingURLs_should_return_result_on_Google_for_InfoTrack()
        {
            WebScrapper ws = new WebScrapper();
            var results = await ws.GetMatchingURLs("test", Core.Enums.SearchEngine.Google, new Uri("https://www.infotrack.com.au"));

            Assert.IsTrue(results.Any());
        }

        [TestMethod]       
        public async Task GetMatchingURLs_should_return_result_on_Bing_for_InfoTrack()
        {
            WebScrapper ws = new WebScrapper();
            var results = await ws.GetMatchingURLs("test", Core.Enums.SearchEngine.Bing, new Uri("https://www.infotrack.com.au"));

            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task CallURL_should_return_valid_string_for_valid_url()
        {
            var result = await WebScrapper.CallUrl("https://www.infotrack.com.au");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InfoTrack.SEO.Application.Exceptions.ApplicationException), "Error occurred while calling URL!")]
        public async Task CallURL_should_fire_exception_for_invalid_url()
        {
            var result = await WebScrapper.CallUrl("https://www.vj.au");
        }
    }
}
