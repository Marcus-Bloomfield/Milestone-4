using ECommerce.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Marcus Bloomfield - 2264053
* Date: 		01 12 2024
* Class Name: 	CustomersController.cs
* Description: 	This controller returns customer information.
* Time for Task:	8h 30mins
    */


namespace ECommerce.Api.Customers.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;

        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
