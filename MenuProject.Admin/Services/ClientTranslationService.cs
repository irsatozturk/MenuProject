using MenuProject.Shared.Models;
using System.Net.Http.Json;

namespace MenuProject.Admin.Services
{
    public class ClientTranslationService
    {
        private readonly HttpClient _http;
        // Çevirileri Hızlı Aramak için Sözlük (Dictionary) kullanıyoruz
        private Dictionary<string, string> _translations = new();

        public ClientTranslationService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("MenuAPI");
        }

        // API'den verileri çekip sözlüğe doldurur
        public async Task LoadTranslationsAsync(string langCode)
        {
            try
            {
                var list = await _http.GetFromJsonAsync<List<LanguageResource>>($"/api/Menu/Resources?lang={langCode}");

                if (list != null)
                {
                    _translations = list.ToDictionary(k => k.Key, v => v.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Çeviri yükleme hatası: " + ex.Message);
            }
        }

        // Anahtar verince metni döndürür. Bulamazsa anahtarın kendisini döner.
        public string Get(string key)
        {
            return _translations.ContainsKey(key) ? _translations[key] : $"[{key}]";
        }
    }
}