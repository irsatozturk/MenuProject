namespace MenuProject.Shared.Models
{
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}