namespace MenuProject.Shared.Models
{
    public class MenuTranslation
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int MenuId { get; set; }

        // JsonIgnore ekliyoruz kısır döngüye girmesin.
        [System.Text.Json.Serialization.JsonIgnore]
        public Menu? Menu { get; set; }
    }
}