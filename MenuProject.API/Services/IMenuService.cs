using MenuProject.Shared.Models;

namespace MenuProject.API.Services
{
    public interface IMenuService
    {
        Task<Menu> GetDefaultMenuAsync(string languageCode);
        Task<IEnumerable<Menu>> GetAllMenusAsync(string languageCode);
        Task CreateMenuAsync(Menu menu);
    }
}