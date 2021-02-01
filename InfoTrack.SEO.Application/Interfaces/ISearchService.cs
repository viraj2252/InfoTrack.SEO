using InfoTrack.SEO.Application.Models;
using InfoTrack.SEO.Core.Entities;
using InfoTrack.SEO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrack.SEO.Application.Interfaces
{
    public interface ISearchService
    {
        Task<SearchOccurrence> Search(string keywords, Uri url, SearchEngine searchEngine);
    }
}
