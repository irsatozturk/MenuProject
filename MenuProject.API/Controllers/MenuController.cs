using MenuProject.API.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Default")]
        public async Task<IActionResult> GetDefaultMenu(string language = "tr")
        {
            var menu = await _menuService.GetDefaultMenuAsync(language);

            if (menu == null)
            {
                return NotFound("Varsayılan menü bulunamadı.");
            }

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
            await _menuService.CreateMenuAsync(menu);
            return Ok(menu);
        }
    }
}

/*
###var menu = await _menuService.GetDefaultMenuAsync(language);###

bu satır Controller'ın işi MenuService'e "havale ettiği" ve ondan gelen sonucu (await ile) beklediği an. 
Controller, Servis'in ne yaptığını bilmez, sadece ondan GetAllMenusAsync işini yapmasını ister.
 */