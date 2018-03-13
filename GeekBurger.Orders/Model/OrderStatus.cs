using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
