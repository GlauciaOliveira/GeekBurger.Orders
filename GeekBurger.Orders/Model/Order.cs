using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Orders.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public string OrderStatusPagamento { get; set; }
        public string NumberCartaoCredito { get; set; }
        public string NameCartaoCredito { get; set; }
        public string Cvv { get; set; }
        public string ValidadeDate { get; set; }

    }
}
