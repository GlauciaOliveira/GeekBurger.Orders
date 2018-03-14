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

            List<Item> itens1 = new List<Item>();
            itens1.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Pão sírio" });
            itens1.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Chedar" });
            itens1.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Tomate" });

            List<Product> produtos1 = new List<Product>();
            produtos1.Add(new Product() { ProductId = Guid.NewGuid(), Name = "X-Miséria", Items = itens1 });

            List<Item> itens2 = new List<Item>();
            itens2.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Pão Integral" });
            itens2.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Queijo branco" });
            itens2.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Tomate" });
            itens2.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Orégano" });

            List<Product> produtos2 = new List<Product>();
            produtos2.Add(new Product() { ProductId = Guid.NewGuid(), Name = "X-Fome", Items = itens2 });

            List<Item> itens3 = new List<Item>();
            itens3.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Pão de Hamburguer" });
            itens3.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Mussarela" });
            itens3.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Tomate" });
            itens3.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Hamburguer bovino" });
            itens3.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Bacon" });
            itens3.Add(new Item() { ItemId = Guid.NewGuid(), Name = "Maionese" });

            List<Product> produtos3 = new List<Product>();
            produtos3.Add(new Product() { ProductId = Guid.NewGuid(), Name = "X-Delicia", Items = itens3 });

            
            context.Order.AddRange(new List<Order> {
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, OrderStatus = OrderStatus.Status.Aberto.ToString() ,Products = produtos1},
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, OrderStatus = OrderStatus.Status.Andamento.ToString() ,Products = produtos2},
                new Order { OrderId = Guid.NewGuid(), RequestDate = DateTime.Now, OrderStatus = OrderStatus.Status.Finalizado.ToString() ,Products = produtos3}
            });

            context.SaveChanges();
        }
    }
}
