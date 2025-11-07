// İçerik: Models/Product.cs
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuProject.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Hangi Kategoriye ait?
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Çevirileri
        public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
    }
}