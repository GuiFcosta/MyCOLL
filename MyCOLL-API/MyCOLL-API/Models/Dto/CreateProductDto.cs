using MyCOLL_API.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyCOLL_API.Models.Dto
{
    public class CreateProductDto
    {
        [Key]
        public long Id { get; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public double BasePrice { get; set; }

        [Range(0, 1)]
        public double SellTax { get; set; }

        [Required]
        public State State { get; set; }

        [Required]
        public Quality Quality { get; set; }
    }
}
