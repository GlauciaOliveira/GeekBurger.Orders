using GeekBurger.Products.Contract;
using System;
using System.Collections.Generic;

namespace GeekBurger.Orders.Contract
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<ProductToGet> Products { get; set; }
    }
}
