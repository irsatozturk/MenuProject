namespace MenuProject.API.Models
{
    public class MenuTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } // "tr"
        public string Name { get; set; } // "Yaz Menüsü"
        // Hangi Menüye ait?
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}