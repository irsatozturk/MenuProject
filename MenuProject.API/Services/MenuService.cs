using MenuProject.API.Data;
using MenuProject.Shared.Models;
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

        public async Task<IEnumerable<Menu>> GetAllMenusAsync(string languageCode)
        {
            var menus = await _context.Menus
                .AsNoTracking()
                .Include(m => m.Translations.Where(t => t.LanguageCode == languageCode))
                .ToListAsync();
            return menus;
        }

        public async Task CreateMenuAsync(Menu menu)
        {
            // SORU: Eğer yeni gelen menü "Varsayılan" (IsDefault) olarak işaretlendiyse...
            if (menu.IsDefault)
            {
                // 1. Veritabanındaki MEVCUT varsayılan menüyü bulmamız lazım.
                // (FirstOrDefaultAsync ile IsDefault == true olanı ara)
                var existingDefault = await _context.Menus.FirstOrDefaultAsync(m => m.IsDefault);

                // 2. Eğer böyle bir menü varsa, onun tahtını elinden al (False yap)
                if (existingDefault != null)
                {
                    existingDefault.IsDefault = false;
                    // EF Core bunu izlediği için, SaveChanges dediğimizde bunu da günceller.
                }
            }

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
        }

        // --- BU METODU EKLEYİN ---
        public async Task<LanguageSettingsDto> GetLanguageSettingsAsync()
        {
            // 1. Tüm ayarları çek
            var settings = await _context.CompanySettings.ToListAsync();

            // 2. "SupportedLanguages" ayarını bul (Yoksa varsayılan 'tr' olsun)
            var supportedStr = settings
                .FirstOrDefault(x => x.Name == "SupportedLanguages")?.Value ?? "tr";

            // 3. "DefaultLanguage" ayarını bul (Yoksa varsayılan 'tr' olsun)
            var defaultLang = settings
                .FirstOrDefault(x => x.Name == "DefaultLanguage")?.Value ?? "tr";

            // 4. String'i listeye çevir ("tr,en" -> List<string>)
            var supportedList = supportedStr
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            // 5. Paketi oluştur ve dön
            return new LanguageSettingsDto
            {
                DefaultLanguage = defaultLang,
                SupportedLanguages = supportedList
            };
        }

        public async Task DeleteMenuAsync(int id)
        {
            // 1. Önce silinecek kaydı bulmalıyız
            var menu = await _context.Menus.FindAsync(id);

            // 2. Eğer kayıt varsa silme işlemini yap
            if (menu != null)
            {
                _context.Menus.Remove(menu); // Silinecek diye işaretle
                await _context.SaveChangesAsync(); // Veritabanına uygula
            }
        }

        public async Task<List<LanguageResource>> GetResourceKeysAsync(string languageCode)
        {
            // İstenen dildeki tüm anahtarları getir
            return await _context.LanguageResources
                .Where(x => x.LanguageCode == languageCode)
                .ToListAsync();
        }

        public async Task<Menu?> GetMenuByIdAsync(int id)
        {
            // Düzenleme sayfasında çevirileri de görmek istediğimiz için
            // Include ile onları da çekmeliyiz.
            return await _context.Menus
                .Include(m => m.Translations) // Çevirileri unutma!
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            // 1. Eğer bu menü varsayılan yapıldıysa, diğerlerini false yap (Create'deki gibi)
            if (menu.IsDefault)
            {
                var existingDefault = await _context.Menus
                    .FirstOrDefaultAsync(m => m.IsDefault && m.Id != menu.Id); // Kendisi hariç!

                if (existingDefault != null)
                {
                    existingDefault.IsDefault = false;
                }
            }

            // 2. Güncelleme Komutu
            // SORU: EF Core'da bir kaydın değiştiğini ve güncellenmesi gerektiğini 
            // belirten komut nedir? (Add ekler, Remove siler, peki bu?)
            _context.Menus.Update(menu);

            await _context.SaveChangesAsync();
        }

    }
}