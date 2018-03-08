using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurger.Orders.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {

        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;

        [HttpGet("{id}", Name = "GetOrdersByOrderId")]
        public IActionResult GetOrdersByOrderId(Guid orderId)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateStatusOrder(Guid orderId, [FromBody] JsonPatchDocument<Order> order)
        {
            return Ok();
        }

        [HttpPost()]
        public IActionResult GetAllOrders()
        {
            return Ok();
        }
    }
}