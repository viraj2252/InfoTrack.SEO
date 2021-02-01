using InfoTrack.SEO.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.SEO.Test.CoreTests
{
    [TestClass]
    public class SearchOccurrenceTests
    {
        [TestMethod]
        public void Create_SearchOccurrence()
        {
            var testUrl = "http://google.com";
            var testResults = new int[] { 2 };

            var search = SearchOccurrence.Create(testUrl, testResults);

            Assert.IsNotNull(search);
            Assert.AreEqual(testUrl, search.URL);
            Assert.AreEqual(testResults.Length, search.Occurrences.Length);
        }
    }
}
