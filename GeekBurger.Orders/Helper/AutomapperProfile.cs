using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductToUpsert, Product>().AfterMap<MatchStoreFromRepository>();
            CreateMap<Product, ProductToUpsert>();
            CreateMap<ItemToUpsert, Item>().AfterMap<MatchItemsFromRepository>();
            CreateMap<Product, ProductToGet>();
            CreateMap<Item, ItemToGet>();
            CreateMap<EntityEntry<Product>, ProductChangedMessage>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Entity));
        }
    }
}
