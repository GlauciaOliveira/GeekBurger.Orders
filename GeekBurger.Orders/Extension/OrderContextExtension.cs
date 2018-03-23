using GeekBurger.Orders.Model;
using GeekBurger.Orders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Orders.Extension
{
    public static class OrderContextExtension
    {
        public static void Seed(this OrdersContext context)
        {

            context.Order.RemoveRange(context.Order);
            context.SaveChanges();
           /* context.Order.AddRange(new List<Order> {
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, OrderStatus = OrderStatus.Status.Aberto.ToString() ,Products = produtos1},
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, OrderStatus = OrderStatus.Status.Andamento.ToString() ,Products = produtos2},
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, OrderStatus = OrderStatus.Status.Finalizado.ToString() ,Products = produtos3}
            });*/

            context.SaveChanges();
        }
    }
}
