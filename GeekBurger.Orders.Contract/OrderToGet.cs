using System;
using System.Collections.Generic;

namespace GeekBurger.Orders.Contract
{
    public class OrderToGet
    {
        public Guid OrderId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string OrderStatus { get; set; }
        public string OrderStatusPagamento { get; set; }
        
     
    }
}
