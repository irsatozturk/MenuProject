using MenuProject.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuProject.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

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