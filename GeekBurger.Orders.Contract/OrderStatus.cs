﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Orders.Contract
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
