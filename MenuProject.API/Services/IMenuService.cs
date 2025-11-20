using MenuProject.Shared.Models;

namespace MenuProject.API.Services
{
    public interface IMenuService
    {
        Task<Menu> GetDefaultMenuAsync(string languageCode);

        // Tüm menüleri getiren metot
        Task<IEnumerable<Menu>> GetAllMenusAsync(string languageCode);

        // Yeni menü ekleme metodu
        Task CreateMenuAsync(Menu menu);

        // Dil ayarlarını getiren metot
        Task<LanguageSettingsDto> GetLanguageSettingsAsync();

        // Menü silme metodu
        Task DeleteMenuAsync(int id);

        // Dil kaynaklarını getiren metot
        Task<List<LanguageResource>> GetResourceKeysAsync(string languageCode);

        // Belirli bir menüyü ID ile getiren metot, düzenleme ve silme işlemleri için
        Task<Menu?> GetMenuByIdAsync(int id);

        // Menü güncelleme metodu
        Task UpdateMenuAsync(Menu menu);
    }
}