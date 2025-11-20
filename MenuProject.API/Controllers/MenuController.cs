using MenuProject.API.Services;
using MenuProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace MenuProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // 1. Varsayılan Menüyü Getir (Home Sayfası İçin)
        // GET: api/Menu/Default
        [HttpGet("Default")]
        public async Task<IActionResult> GetDefaultMenu(string language = "tr")
        {
            var menu = await _menuService.GetDefaultMenuAsync(language);
            if (menu == null) return NotFound("Varsayılan menü bulunamadı.");
            return Ok(menu);
        }

        // 2. Tüm Menüleri Listele (Yönetim Paneli Listesi İçin) - EKSİK OLAN BU OLABİLİR
        // GET: api/Menu
        [HttpGet]
        public async Task<IActionResult> GetAllMenus(string language = "tr")
        {
            var menus = await _menuService.GetAllMenusAsync(language);
            return Ok(menus);
        }

        // 3. Yeni Menü Yarat
        // POST: api/Menu
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
        {
            await _menuService.CreateMenuAsync(menu);
            return Ok(menu);
        }

        // 4. Menü Sil
        // DELETE: api/Menu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            await _menuService.DeleteMenuAsync(id);
            return Ok();
        }

        // 5. Dil Kaynaklarını Getir (Dinamik Form İçin)
        // GET: api/Menu/Languages
        [HttpGet("Languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var settings = await _menuService.GetLanguageSettingsAsync();
            return Ok(settings);
        }

        // 6. Çevirileri Getir (Toast Bildirimleri İçin)
        // GET: api/Menu/Resources
        [HttpGet("Resources")]
        public async Task<IActionResult> GetResources(string lang = "tr")
        {
            var resources = await _menuService.GetResourceKeysAsync(lang);
            return Ok(resources);
        }

        // 1. Tek bir menüyü getiren endpoint
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuByIdAsync(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        // 2. Güncelleme işlemini yapan endpoint
        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromBody] Menu menu)
        {
            await _menuService.UpdateMenuAsync(menu);
            return Ok(menu);
        }
    }
}