﻿using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductCategory,
                o => o.MapFrom(s => s.ProductCategory.Title))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        CreateMap<CustomerBasketDto, CustomerBasket>();
        CreateMap<BasketItemDto, BasketItem>();
    }
}