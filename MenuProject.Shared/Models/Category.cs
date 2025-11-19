namespace MenuProject.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Menu? Menu { get; set; }
        
        public ICollection<CategoryTranslation> Translations { get; set; } = new List<CategoryTranslation>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}