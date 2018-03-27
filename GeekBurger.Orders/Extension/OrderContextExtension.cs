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
            context.Order.AddRange(new List<Order> {
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, PaymentDate =  DateTime.Now, OrderStatusPagamento="Pendente", NumberCartaoCredito="9998666444333",Cvv="176",NameCartaoCredito="Andre Luiz", ValidadeDate="02/2024"},
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, PaymentDate =  DateTime.Now, OrderStatusPagamento="Finalizado",NumberCartaoCredito="99986688888",Cvv="189",NameCartaoCredito="Luiza Mel", ValidadeDate="08/2028"},
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, PaymentDate =  DateTime.Now, OrderStatusPagamento="Pendente",NumberCartaoCredito="9998666477777",Cvv="112",NameCartaoCredito="Rodrigo Santos", ValidadeDate="04/2028"}
            });



        context.SaveChanges();
        }
    }
}
