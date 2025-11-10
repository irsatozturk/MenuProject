namespace MenuProject.API.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsDefault { get; set; } = false;
        public ICollection<MenuTranslation> Translations { get; set; } = new List<MenuTranslation>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}