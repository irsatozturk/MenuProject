namespace MenuProject.API.Models
{
    public class ProductTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } // "tr"
        public string Name { get; set; } // "Adana Kebabı"
        public string Description { get; set; } // "Acılı, özel..."
        // Hangi Ürüne ait?
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}