using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Orders.Contract
{
   public class OrderStatusPagamento
    {
        public enum StatusPagamento
        {
            Pago,
            Pendente
        };
    }
}
