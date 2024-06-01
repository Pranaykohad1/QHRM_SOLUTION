using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QHRM.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Precision(16,2)]
        public decimal price { get; set; }

        [MaxLength(100)]
        public string Description { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}
