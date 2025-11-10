using MenuProject.API.Data; // DbContext için
using MenuProject.API.Models;
using Microsoft.EntityFrameworkCore; // EF Core özellikleri için. Örn: Include, ThenInclude, AsNoTracking, vb.

namespace MenuProject.API.Services
{
    public class MenuService : IMenuService // MenuService, IMenuService sözleşmesini çalıştırır
    {
        private readonly ApplicationDbContext _context; // DbContext için bir alan tanımlıyoruz

        public MenuService(ApplicationDbContext context) // Yapıcı metod ile DbContext'i alıyoruz. 
        {
            _context = context; // Burada dbContext'i alanımıza atıyoruz
        }

        public async Task<Menu> GetDefaultMenuAsync(string languageCode) // Varsayılan menüyü belirtilen dil koduyla al
        {
            var menu = await _context.Menus // Menüler DbSet'ine eriş
                .AsNoTracking() // Değişiklik takibini devre dışı bırak (yalnızca okuma işlemi için performans iyileştirmesi)
                .Where(m => m.IsDefault) // Sadece varsayılan menüyü filtrele

                // 1. Menünün çevirilerini yükle (sadece istenen dilde)
                .Include(m => m.Translations.Where(t => t.LanguageCode == languageCode))

                // 2. Menünün Kategorilerini yükle
                .Include(m => m.Categories)
                    // 3. Bu Kategorilerin çevirilerini yükle (sadece istenen dilde)
                    .ThenInclude(c => c.Translations.Where(t => t.LanguageCode == languageCode))

                // 4. Menünün Kategorilerini *tekrar* dahil et (Kategorilerin Ürünlerini yüklemek için)
                .Include(m => m.Categories)
                    // 5. Kategorilerin Ürünlerini yükle
                    .ThenInclude(c => c.Products)
                        // 6. Bu Ürünlerin çevirilerini yükle (sadece istenen dilde)
                        .ThenInclude(p => p.Translations.Where(t => t.LanguageCode == languageCode))

                .FirstOrDefaultAsync(); // Eşleşen ilk (ve tek) varsayılan menüyü al

            return menu;
        }
    }
}