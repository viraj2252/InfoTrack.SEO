using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InfoTrack.SEO.API.Models;
using InfoTrack.SEO.API.Models.Requests;
using InfoTrack.SEO.Application.Interfaces;
using InfoTrack.SEO.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoTrack.SEO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IAppLogger<SearchController> _logger;
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(IAppLogger<SearchController> logger, ISearchService searchService, IMapper mapper)
        {
            _logger = logger;
            _searchService = searchService;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();

        }
        // POST api/<SearchController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SearchRequest request)
        {
            try
            {
                var searchResult = await _searchService.Search(request.Keywords, new Uri(request.URL), request.SearchEngine);
                return Ok(_mapper.Map<SearchResponseViewData>(searchResult));
            }
            catch (UriFormatException ex)
            {
                _logger.LogException("Error occurred in SearchController", ex);
                return BadRequest("URL provided is not in correct format!");
            }
            catch(Exception ex)
            {
                _logger.LogException("Error occurred in SearchController", ex);
                return BadRequest("Error Occurred!");
            }
            
        }
    }
}
