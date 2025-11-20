namespace MenuProject.Shared.Models
{
    public class LanguageSettingsDto
    {
        // Varsayılan dil (Örn: "tr")
        public string DefaultLanguage { get; set; } = "tr";

        // Desteklenen diller listesi (Örn: ["tr", "en"])
        public List<string> SupportedLanguages { get; set; } = new List<string>();
    }
}