using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Marcus Bloomfield - 2264053
* Date: 		01 12 2024
* Class Name: 	SearchController.cs
* Description: 	This controller returns information on all services based on the customer Id using a search method.
* Time for Task:	8h 30mins
    */

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }

        
    }
}
