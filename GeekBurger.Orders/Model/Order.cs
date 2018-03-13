using GeekBurger.Products.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Orders.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public string OrderStatus { get; set; }
        public List<ProductToGet> Products { get; set; } = new List<ProductToGet>();

    }
}
