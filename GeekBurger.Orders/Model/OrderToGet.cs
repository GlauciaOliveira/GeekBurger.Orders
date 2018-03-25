using GeekBurger.Products.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Orders.Model
{
    public class OrderToGet
    {
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<ItemToGet> Items { get; set; }
    }
}
