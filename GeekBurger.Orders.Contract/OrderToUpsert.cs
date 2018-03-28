using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Orders.Contract
{
   public class OrderToUpsert
    {
     
        public DateTime RequestDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string OrderStatus { get; set; }
        public string OrderStatusPagamento { get; set; }
        public string NumberCartaoCredito { get; set; }
        public string NameCartaoCredito { get; set; }
        public string Cvv { get; set; }
        public string ValidadeDate { get; set; }
    }
}
