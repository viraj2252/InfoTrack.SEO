using AutoMapper;
using InfoTrack.SEO.API.Models;
using InfoTrack.SEO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.SEO.API.Mapper
{
    public class SearchProfile: Profile
    {
        public SearchProfile()
        {
            CreateMap<SearchOccurrence, SearchResponseViewData>()
                .ForMember(d => d.Occurrences, o => o.MapFrom(s => String.Concat(s.Occurrences)));
        }
    }
}
