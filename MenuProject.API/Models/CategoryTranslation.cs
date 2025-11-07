namespace MenuProject.API.Models
{
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } // "tr"
        public string Name { get; set; } // "Ana Yemekler"
        // Hangi Kategoriye ait?
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}