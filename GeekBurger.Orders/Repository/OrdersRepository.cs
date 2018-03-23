using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Service;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Orders.Repository
{
    public class OrdersRepository : IOrdersRepository
    {

        private OrdersContext _context;
        private IOrderPaidService _orderPaidService;

        public OrdersRepository(OrdersContext context, IOrderPaidService orderPaidService)
        {
            _context = context;
            _orderPaidService = orderPaidService;
        }

        public bool Add(Order order)
        {
            order.OrderId = Guid.NewGuid();
            _context.Order.Add(order);
            return true;
        }

        public Order GetOrderById(Guid orderId)
        {
            return _context.Order
                            .Where(o => o.OrderId.Equals(orderId))
                            .FirstOrDefault();
        }

        public List<Order> ListAllOrders()
        {
            return _context.Order
                            .Include("Orders")
                            .ToList();
        }

        public void Save()
        {
            _orderPaidService
                .AddToMessageList(_context.ChangeTracker.Entries<Order>());

            _context.SaveChanges();

            _orderPaidService.SendMessagesAsync();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
