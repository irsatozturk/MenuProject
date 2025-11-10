using MenuProject.API.Models;

namespace MenuProject.API.Services
{
    public interface IMenuService
    {
        Task<Menu> GetDefaultMenuAsync(string languageCode);
        //Task -> Asenkron bir işlem olduğunu belirtir
        //Menu -> Döndürülecek veri türünü belirtir. Burada menu modeli döndürülecek
        //GetDefaultMenuAsync -> Metodun adını böyle koyduk, tüm tasklar asenkron olduğu için ismin sonuna "Async" ekledik
        //string languageCode -> Metodun parametresini belirtir, dil kodunu parametre olarak gönderiyoruz
    }
}
