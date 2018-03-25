using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Repository;
using AutoMapper;
using GeekBurger.Orders.Helper;

namespace GeekBurger.Orders.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {

        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;

        public OrdersController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        [HttpPost()]
        public IActionResult AddOrder([FromBody] Order orderAdd)
        {
            if (orderAdd == null)
                return BadRequest();

            var order = _mapper.Map<Order>(orderAdd);

            if (order.OrderId == Guid.Empty)
                return new UnprocessableEntityResult(ModelState);

            _ordersRepository.Add(order);
            _ordersRepository.Save();

            var orderToGet = _mapper.Map<Order>(order);

            return CreatedAtRoute("GetOrder",
                new { id = orderToGet.OrderId },
                orderToGet);
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public IActionResult GetOrderById(Guid orderId)
        {
            var order = _ordersRepository.GetOrderById(orderId);

            var orderToGet = _mapper.Map<Order>(order);

            return Ok(orderToGet);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateOrder(Guid orderId, [FromBody] JsonPatchDocument<Order> orderPatch)
        {
            Order order;

            if (orderPatch == null)
                return BadRequest();

            order = _ordersRepository.GetOrderById(orderId);

            if (orderId == null || order == null)
            {
                return NotFound();
            }

            var orderToUpdate = _mapper.Map<Order>(order);
            orderPatch.ApplyTo<Order>(orderToUpdate, ModelState);

            order = _mapper.Map(orderToUpdate, order);

            if (order.OrderId == Guid.Empty)
                return new UnprocessableEntityResult(ModelState);

            _ordersRepository.Update(order);
            _ordersRepository.Save();

            var orderToGet = _mapper.Map<Order>(order);

            return CreatedAtRoute("GetOrder",
                new { id = orderToGet.OrderId },
                orderToGet);
        }

        [HttpGet()]
        public IActionResult GetAllOrders()
        {
            var orders = _ordersRepository.ListAllOrders();

            var listOrders = _mapper.Map<List<Order>>(orders);

            return Ok(listOrders);
        }
    }
}