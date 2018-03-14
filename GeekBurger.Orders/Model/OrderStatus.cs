using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Orders.Model
{
    public class OrderStatus
    {
        public enum Status
        {
            Aberto,
            Andamento,
            Finalizado,
            Cancelado
        };
    }
}
