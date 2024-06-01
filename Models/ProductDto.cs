using System.ComponentModel.DataAnnotations;

namespace QHRM.Models
{
    public class ProductDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        public decimal price { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; } = "";

    }
}
