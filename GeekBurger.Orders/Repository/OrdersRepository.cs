using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Service;

namespace GeekBurger.Orders.Repository
{
    public class OrdersRepository : IOrdersRepository
    {

        private OrdersContext _context;
        private IOrderChangedService _orderChangedService;

        public OrdersRepository(OrdersContext context, IOrderChangedService orderChangedService)
        {
            _context = context;
            _orderChangedService = orderChangedService;
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
            return _context.Order.ToList();
        }

        public void Save()
        {
            _orderChangedService
                .AddToMessageList(_context.ChangeTracker.Entries<Order>());

            _context.SaveChanges();

            _orderChangedService.SendMessagesAsync();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
