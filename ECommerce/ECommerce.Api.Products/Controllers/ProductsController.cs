using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Marcus Bloomfield - 2264053
* Date: 		01 12 2024
* Class Name: 	ProductsController.cs
* Description: 	This controller returns Product information.
* Time for Task:	8h 30mins
    */

namespace ECommerce.Api.Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productsProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
