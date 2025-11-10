using MenuProject.API.Data;
using MenuProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuProject.API.Services
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> GetDefaultMenuAsync(string languageCode)
        {
            var menu = await _context.Menus
                .AsNoTracking()
                .Where(m => m.IsDefault)

                .Include(m => m.Translations.Where(t => t.LanguageCode == languageCode))

                .Include(m => m.Categories)
                    .ThenInclude(c => c.Translations.Where(t => t.LanguageCode == languageCode))

                .Include(m => m.Categories)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(p => p.Translations.Where(t => t.LanguageCode == languageCode))

                .FirstOrDefaultAsync();

            return menu;
        }
    }
}