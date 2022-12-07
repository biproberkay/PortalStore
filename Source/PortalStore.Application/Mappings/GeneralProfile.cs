using AutoMapper;
using PortalStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStore.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Category, CategoryCore>().ReverseMap();
            CreateMap<Product, ProductCore>().ReverseMap();
            // OrderItem
            CreateMap<OrderItem, OrderItemCore>().ReverseMap();
            // Order
            CreateMap<Order, OrderCore>().ReverseMap();
            // Customer
            CreateMap<Customer, CustomerCore>().ReverseMap();
            // Address
            CreateMap<Address, AddressCore>().ReverseMap();
        }
    }
}
