namespace MenuProject.Shared.Models
{
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Category? Category { get; set; }
    }
}