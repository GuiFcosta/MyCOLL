using AutoMapper;
using MyCOLL.Admin.Models.DTO.ProductDTO;
using MyCOLL.Admin.Models.Entities;

namespace MyCOLL.Admin.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entity -> ReadDTO
        CreateMap<Product, ProductReadDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.UserName)) // Ou FullName
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.ToString()))
            .ForMember(dest => dest.AvailabilityMode, opt => opt.MapFrom(src => src.AvailabilityMode.ToString()));
        
        // CreateDTO -> Entity
        CreateMap<ProductCreateDto, Product>();

        // UpdateDTO -> Entity
        CreateMap<ProductUpdateDto, Product>();
    }
}