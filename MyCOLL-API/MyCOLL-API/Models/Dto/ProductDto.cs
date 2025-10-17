using MyCOLL_API.Models.Entities;

namespace MyCOLL_API.Models.Dto
{
    public class ProductDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double BasePrice { get; set; }
        public double SellTax { get; set; }
        public State State { get; set; }
        public Quality Quality { get; set; }
    }
}
