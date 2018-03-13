using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekBurger.Orders.Service
{
    public class OrderChangedService : IOrderChangedService
    {
        public void AddToMessageList(IEnumerable<EntityEntry<Order>> changes)
        {
            throw new NotImplementedException();
        }

        public void SendMessagesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
