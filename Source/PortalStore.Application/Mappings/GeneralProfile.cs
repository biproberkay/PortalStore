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
            //Category
            //CreateDto
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            //EditDto
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            //ReadDtoDto
            CreateMap<Category, CategoryReadDto>().ReverseMap();

            //Product 
            //CreateDto
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            //EditDto
            CreateMap<Product, ProductEditDto>().ReverseMap();
            //ReadDtoDto
            CreateMap<Product, ProductReadDto>().ReverseMap();
            
            // OrderItem
            //CreateDto
            CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap();
            //EditDto
            CreateMap<OrderItem, OrderItemEditDto>().ReverseMap();
            //ReadDtoDto
            CreateMap<OrderItem, OrderItemReadDto>().ReverseMap();
            
            // Order
            //CreateDto
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            //EditDto
            CreateMap<Order, OrderEditDto>().ReverseMap();
            //ReadDtoDto
            CreateMap<Order, OrderReadDto>().ReverseMap();
            
            // Customer
            //CreateDto
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerEditDto>().ReverseMap();
            CreateMap<Customer, CustomerReadDto>().ReverseMap();

            // Address
            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AddressEditDto>().ReverseMap();
            CreateMap<Address, AddressReadDto>().ReverseMap();
        }
    }
}
