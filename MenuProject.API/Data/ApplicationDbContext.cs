// İçerik: Data/ApplicationDbContext.cs
using MenuProject.API.Models; // Model klasörümüzü tanıttık
using Microsoft.EntityFrameworkCore; // EF Core kütüphanesi

namespace MenuProject.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Bu 'constructor', .NET Core'un veritabanı ayarlarını
        // bu sınıfa iletmesini sağlar (bir sonraki adımda yapacağız).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // --- Veritabanı Tablolarımızı (DbSet) Tanımlıyoruz ---
        // EF Core, buradaki her DbSet için bir tablo oluşturacak.

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuTranslation> MenuTranslations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<LanguageResource> LanguageResources { get; set; }
    }
}