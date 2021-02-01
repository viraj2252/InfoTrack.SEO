using InfoTrack.SEO.Application.Interfaces;
using InfoTrack.SEO.Application.Models;
using InfoTrack.SEO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Application.Helpers
{
    public class WebScrapper
    {
        public static async Task<string> CallUrl(string fullUrl)
        {
            try
            {
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.GetStringAsync(fullUrl);
                return await response;
            }
            catch (Exception ex)
            {

                throw new InfoTrack.SEO.Application.Exceptions.ApplicationException("Error occurred while calling URL!", ex);
            }
           
        }
        public async Task<IEnumerable<LinkItem>> GetMatchingURLs(string keywords, SearchEngine searchEngine, Uri urlToSearch, int limit = 50)
        {
            string urlPlaceholder = "https://infotrack-tests.infotrack.com.au/{0}/Page{1}.html";
            int resultCount = 0;
            List<LinkItem> result = new List<LinkItem>();

            for (int i = 1; i <= 10; i++)
            {
                if (resultCount >= limit)
                    break;

                var url = string.Format(urlPlaceholder, searchEngine.ToString(), i.ToString("00"));    
                var response = await CallUrl(url);

                var scrapeResult = LinkFinder.Find(response, searchEngine, resultCount+1);


                //Make sure resultCount <= limit
                if (resultCount + scrapeResult.Count > limit)
                    scrapeResult.RemoveRange((limit - resultCount - 1), scrapeResult.Count - (limit - resultCount));

                resultCount += scrapeResult.Count;
                result.AddRange(scrapeResult.Where(t => t.Href.StartsWith(urlToSearch.ToString())));
            }

            return result;
        }
    }    

    static class LinkFinder
    {
        public static List<LinkItem> Find(string content, SearchEngine searchEngine, int startingIndex = 1)
        {
            List<LinkItem> list = new List<LinkItem>();

            // 1.
            // Find all matches in file.
            MatchCollection m1 = null;

            if (searchEngine == SearchEngine.Google)
            {
                m1 = Regex.Matches(content, @"(<div class=\""r\"">.*?</div>)",
                    RegexOptions.Singleline);
            }
            else
            {
                m1 = Regex.Matches(content, @"(<li class=\""b_algo\"">.*?</li>)",
                    RegexOptions.Singleline);
            }

            // 2.
            // Loop over each match.
            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                LinkItem i = new LinkItem();

                // 3.
                // Get href attribute.
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""",
                    RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4.
                // Remove inner tags from text.
                string t = Regex.Replace(value, @"\s*<.*?>\s*", "",
                    RegexOptions.Singleline);
                i.Text = t;
                i.Index = startingIndex++;

                list.Add(i);
            }
            return list;
        }
    }
}
