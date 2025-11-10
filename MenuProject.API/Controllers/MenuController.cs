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
    }
}