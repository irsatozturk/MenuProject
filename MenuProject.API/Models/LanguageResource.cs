// İçerik: Models/LanguageResource.cs
namespace MenuProject.API.Models
{
    public class LanguageResource
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; } // "tr"
        public string Key { get; set; } // "homepage_title"
        public string Value { get; set; } // "Anasayfa"
    }
}