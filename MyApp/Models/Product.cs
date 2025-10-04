using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Product
    {
        [Key] public Guid ProductId { get; set; } = Medo.Uuid7.NewGuid();
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public decimal Price { get; set; }

        [Index(IsUnique = true)]
        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(255)] public string ImageUrl { get; set; }

        [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}