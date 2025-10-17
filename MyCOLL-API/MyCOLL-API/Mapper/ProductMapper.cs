using MyCOLL_API.Models.Dto;
using MyCOLL_API.Models.Entities;

namespace MyCOLL_API.Mapper
{
    public class ProductMapper
    {
        public static ProductDto EntityToDto(Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BasePrice = product.BasePrice,
                SellTax = product.SellTax,
                State = product.State,
                Quality = product.Quality,
            };
        }
        public static Product DtoToEntity(ProductDto productDto)
        {
            if (productDto is null) throw new ArgumentNullException(nameof(productDto));
            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                BasePrice = productDto.BasePrice,
                SellTax = productDto.SellTax,
                State = productDto.State,
                Quality = productDto.Quality,
            };
        }
    }
}
