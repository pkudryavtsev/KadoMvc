using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos;
using AutoMapper;
using ProductDb.DataClasses;
using Services.Dtos.Boxes;
using Services.Dtos.Products;

namespace Services.Tests.Infrastructure
{
    public class TestMappingProfiles : Profile
    {
        public TestMappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name));
            CreateMap<Box, BoxToReturnDto>();
        }
    }
}
