using GeekBurger.Orders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Orders.Repository
{
    public interface IOrdersRepository
    {

        Order GetOrderById(Guid orderId);
        List<Order> ListAllOrders();
        bool Add(Order order);
        bool Update(Order order);
        void Delete(Order order);
        void Save();
    }
}
