namespace MenuProject.API.Models
{
    public class CompanySetting
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: "DefaultCurrency"
        public string Value { get; set; } // Örn: "₺"
    }
}