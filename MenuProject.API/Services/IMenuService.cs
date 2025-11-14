using MenuProject.Shared.Models;

namespace MenuProject.API.Services
{
    public interface IMenuService
    {
        Task<Menu> GetDefaultMenuAsync(string languageCode);
        Task<IEnumerable<Menu>> GetAllMenusAsync(string languageCode);
    }
}



/*
###Task<Menu> GetDefaultMenuAsync(string languageCode);###
Task :::: Asenkron bir işlem olduğunu belirtir
<Menu> :::: Döndürülecek veri türünü belirtir. Burada menu modeli döndürülecek
GetDefaultMenuAsync :::: Metodumuzun adı. "Task" ile başlayan tüm metodlar asenkron olduğu için ismin sonuna "Async" eklemek genel kabul görmüş bir yaklaşımdır.
string languageCode :::: Metodun parametresi, dil kodunu parametre gönderiyoruz
 */