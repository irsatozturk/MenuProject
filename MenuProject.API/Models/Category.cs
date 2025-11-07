// İçerik: Models/Category.cs
namespace MenuProject.API.Models
{
    public class Category
    {
        public int Id { get; set; }

        // Hangi Menüye ait?
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        // Çevirileri
        public ICollection<CategoryTranslation> Translations { get; set; } = new List<CategoryTranslation>();

        // Ürünleri
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}