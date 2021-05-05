using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos;
using AutoMapper;
using ProductDb.DataClasses;
using OrderDb.DataClasses;
using Services.Dtos.Orders;
using Services.Dtos.Boxes;
using Services.Dtos.Products;

namespace Services.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        
            CreateMap<Box, BoxToReturnDto>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.BoxProducts.Select(x => x.Product).ToList()))
                .ReverseMap();

            CreateMap<BoxToCreateDto, Box>()
                .ForMember(d => d.BoxProducts, o => o.MapFrom(s => s.ProductIds.Select(p => new BoxProduct { ProductId = p}).ToList()));

             CreateMap<BoxToUpdateDto, Box>()
                .ForMember(d => d.BoxProducts, o => o.MapFrom(s => s.ProductIds.Select(p => new BoxProduct { ProductId = p, BoxId = s.Id}).ToList()));

            CreateMap<ShoppingCartDto, ShoppingCart>();
            CreateMap<ShoppingCartItemDto, ShoppingCartItem>();
            CreateMap<Order, OrderToReturnDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Order, OrdersForUserDto>()
                 .ForMember(d => d.Boxes, o => o.MapFrom(s => s.OrderItems.Select(oi => new OrderBoxDto { Id = oi.BoxId, BoxName = oi.BoxName, Price = oi.Price })));

            CreateMap<Order, OrderDetailsToReturnDto>()
                .ForMember(d => d.OrderDate, o => o.MapFrom(s => s.OrderDate))
                .ForMember(d => d.OrderItems, o => o.MapFrom(s => s.OrderItems))
                .ForMember(d => d.OrderId, o => o.MapFrom(s => s.Id));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.BoxName, o => o.MapFrom(s => s.BoxName))
                .ForMember(d => d.ProductNames, o => o.MapFrom(s => s.OrderProducts.Select(x => x.Name).ToList()));

        }
    }
}
