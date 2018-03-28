using AutoMapper;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
  
            CreateMap<Order, OrderToUpsert>();
            CreateMap<Order, Contract.OrderToGet>();
        }
    }
}
