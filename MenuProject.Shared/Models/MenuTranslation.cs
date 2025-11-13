namespace MenuProject.Shared.Models
{
    public class MenuTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}