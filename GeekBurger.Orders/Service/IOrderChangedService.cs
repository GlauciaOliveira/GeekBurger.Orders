using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Orders.Service
{
    public interface IOrderChangedService
    {
        void SendMessagesAsync();
        void AddToMessageList(IEnumerable<EntityEntry<Order>> changes);
    }
}
