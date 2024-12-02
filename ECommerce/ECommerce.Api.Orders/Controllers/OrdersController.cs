using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

/*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Marcus Bloomfield - 2264053
* Date: 		01 12 2024
* Class Name: 	OrdersController.cs
* Description: 	This controller returns order information.
* Time for Task:	8h 30mins
    */


namespace ECommerce.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;

        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAync()
        {
            var result = await ordersProvider.GetOrdersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
