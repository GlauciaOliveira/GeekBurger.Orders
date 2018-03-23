using GeekBurger.Products.Contract;
using System;
using System.Collections.Generic;

namespace GeekBurger.Orders.Contract
{
    public class OrderPaidToGet
    {
        public Guid OrderId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string OrderStatus { get; set; }
        public string OrderStatusPagamento { get; set; }
        
     
    }
}
