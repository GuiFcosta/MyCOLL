using AutoMapper;
using MyCOLL.Api.Models.DTO.CategoryDTO;
using MyCOLL.Api.Models.DTO.ProductDTO;
using MyCOLL.Api.Models.Entities;

namespace MyCOLL.Api.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Product <-> DTOs
        CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.FinalPrice))
            .ForMember(dest => dest.Condition, opt => opt.MapFrom(src => src.Condition.ToString()))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.ToString()))
            .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name).ToList()));
        
        CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.Categories, opt => opt.Ignore());
        CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.Categories, opt => opt.Ignore());;

        // Category <-> DTOs
        CreateMap<Category, CategoryReadDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products.Select(p => p.Name).ToList()));

        CreateMap<CategoryCreateDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();
    }
}