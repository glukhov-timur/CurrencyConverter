using System.Text.Json;
using CurrencyConverter.Models;

namespace CurrencyConverter.Service
{
    public class APIService
    {
        public async Task<Currency> GetCurrencyAsync(string url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var resultJson = await httpClient.GetAsync(new Uri(url));
                var x = resultJson.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Currency>(await resultJson.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запроса к API: {ex}");
                Console.ReadLine();
                throw;
            }        
        }
    }
}
