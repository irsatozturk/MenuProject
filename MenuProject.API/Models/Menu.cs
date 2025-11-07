namespace MenuProject.API.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDefault { get; set; } = false;
        // Çevirileri
        public ICollection<MenuTranslation> Translations { get; set; } = new List<MenuTranslation>();
        // Kategorileri
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}