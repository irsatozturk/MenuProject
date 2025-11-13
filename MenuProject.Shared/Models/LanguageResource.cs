// Konum: C:\menuProject\MenuProject.Shared\Models\LanguageResource.cs

namespace MenuProject.Shared.Models // 1. Namespace'in bu olduğundan emin olun
{
    public class LanguageResource
    {
        public int Id { get; set; }

        // 2. Bu = null!; eklerini KONTROL EDİN
        public string LanguageCode { get; set; } = null!;
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}