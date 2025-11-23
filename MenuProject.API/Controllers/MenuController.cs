using MenuProject.API.Services;
using MenuProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuProject.API.Data; // Context'in olduğu namespace (Burası sende farklı olabilir, kontrol et)

namespace MenuProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly ApplicationDbContext _context;

        public MenuController(IMenuService menuService, ApplicationDbContext context)
        {
            _menuService = menuService;
            _context = context;
        }

        [HttpGet("Default")]
        public async Task<IActionResult> GetDefaultMenu(string language = "tr")
        {
            var menu = await _menuService.GetDefaultMenuAsync(language);
            if (menu == null) return NotFound("Varsayılan menü bulunamadı.");
            return Ok(menu);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenus(string language = "tr")
        {
            var menus = await _menuService.GetAllMenusAsync(language);
            return Ok(menus);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] Menu menu)
        {
            if (menu.IsDefault)
            {
                menu.IsActive = true;
                var otherDefaults = await _context.Menus.Where(m => m.IsDefault).ToListAsync();
                foreach (var item in otherDefaults) item.IsDefault = false;
            }

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return Ok(menu);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null) return NotFound("Menü bulunamadı.");

            if (menu.IsDefault)
            {
                return BadRequest("Varsayılan (Default) menü silinemez! Önce başka bir menüyü varsayılan yapın.");
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("Languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var settings = await _menuService.GetLanguageSettingsAsync();
            return Ok(settings);
        }

        [HttpGet("Resources")]
        public async Task<IActionResult> GetResources(string lang = "tr")
        {
            // İsim düzeltmesi: Service'de muhtemelen GetResourceKeysAsync diye geçiyor
            var resources = await _menuService.GetResourceKeysAsync(lang);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var menu = await _menuService.GetMenuByIdAsync(id);
            if (menu == null) return NotFound();
            return Ok(menu);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromBody] Menu menu)
        {
            if (menu.IsDefault)
            {
                menu.IsActive = true;
                var otherDefaults = await _context.Menus.Where(m => m.IsDefault && m.Id != menu.Id).ToListAsync();
                foreach (var item in otherDefaults) item.IsDefault = false;
            }

            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
            return Ok(menu);
        }
    }
}