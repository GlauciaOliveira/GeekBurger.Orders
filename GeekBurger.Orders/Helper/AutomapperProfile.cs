using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;

namespace GeekBurger.Orders.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<OrderPaidToUpsert, Order>();
            CreateMap<Order, OrderPaidToUpsert>();
            CreateMap<Order, OrderPaidToGet>();
        }
    }
}
