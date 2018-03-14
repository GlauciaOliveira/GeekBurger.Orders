using GeekBurger.Products.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Orders.Model
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
