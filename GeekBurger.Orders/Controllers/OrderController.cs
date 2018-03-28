using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Repository;
using AutoMapper;
using GeekBurger.Orders.Helper;

namespace GeekBurger.Orders.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;

        public OrderController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(Guid id)
        {
            var order = _ordersRepository.GetOrderById(id);

            var orderToGet = _mapper.Map<OrderToGet>(order);

            return Ok(orderToGet);
        }

        [HttpPost()]
        public IActionResult AddOrder([FromBody] OrderToUpsert orderToAdd)
        {
            if (orderToAdd == null)
                return BadRequest();

            var order = _mapper.Map<Order>(orderToAdd);

            _ordersRepository.Add(order);
            _ordersRepository.Save();

            var orderToGet = _mapper.Map<OrderToGet>(order);

            return CreatedAtRoute("GetOrder",
                new { id = orderToGet.OrderId },
                orderToGet);
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateOrder(Guid id, [FromBody] JsonPatchDocument<OrderToUpsert> orderPatch)
        {
            Order order;

            if (orderPatch == null)
                return BadRequest();

            order = _ordersRepository.GetOrderById(id);

            if (id == null || order == null)
            {
                return NotFound();
            }

            var orderToUpdate = _mapper.Map<OrderToUpsert>(order);
            orderPatch.ApplyTo<OrderToUpsert>(orderToUpdate, ModelState);

            order = _mapper.Map(orderToUpdate, order);

            _ordersRepository.Update(order);
            _ordersRepository.Save();

            var orderToGet = _mapper.Map<OrderToGet>(order);

            return CreatedAtRoute("GetOrder",
                new { id = orderToGet.OrderId },
                orderToGet);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var order = _ordersRepository.GetOrderById(id);

            _ordersRepository.Delete(order);
            _ordersRepository.Save();
            return NoContent();
        }
    }
}