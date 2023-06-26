using OdevApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OdevApp1.Services
{
    internal interface IFılmService
    {
        Task<List<FılmlerM>> GetFılmlerM();
        Task<List<KullanıcılarM>> GetKullanıcılarMs();
        Task Ekle(KullanıcılarM kullanıcılarM);
        Task Guncelle(KullanıcılarM kullanıcılarM);
        Task Sil(Guid kullanıcıId);
        Task<List<FılmlerM>> SearchFılmler(string searchText);
    }
    public class UrlHelper
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7091" : "https://localhost:7091";

        public static string FılmUrl = $"{BaseAddress}/fılmler";
        public static string KullanıcıUrl = $"{BaseAddress}/kullanıcı";

    }
    public class FılmService : IFılmService
    {

        HttpClient httpClient;
        JsonSerializerOptions jsonSerializerOptions;
        public FılmService()
        {
            httpClient = new HttpClient();

            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<FılmlerM>> SearchFılmler(string searchText)
        {
            var response = await httpClient.GetAsync($"{UrlHelper.FılmUrl}?searchText={Uri.EscapeDataString(searchText)}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var allResults = JsonSerializer.Deserialize<List<FılmlerM>>(jsonContent, jsonSerializerOptions);

                if (!string.IsNullOrEmpty(searchText))
                {
                    // Girilen metine kısmi olarak eşleşen sonuçları filtrele
                    var filteredResults = allResults.Where(f => f.FılmAdı.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
                    return filteredResults;
                }
            }



            return new List<FılmlerM>();
        }

        public async Task Ekle(KullanıcılarM kullanıcılarM)
        {
            var json = JsonSerializer.Serialize(kullanıcılarM);

            JsonContent jsonContent = JsonContent.Create(kullanıcılarM);
            var response = await httpClient.PostAsync(UrlHelper.KullanıcıUrl, jsonContent);
            if (response.IsSuccessStatusCode)
            {

            }
        }
       
        public async Task Guncelle(KullanıcılarM kullanıcılarM)
        {
            var jsonContent = JsonContent.Create(kullanıcılarM);
            var response = await httpClient.PostAsync(UrlHelper.KullanıcıUrl + "/guncelle", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı işlem durumunda yapılacak işlemler
            }
        }
            public async Task<List<FılmlerM>> GetFılmlerM()
            {
                var sonuc = await httpClient.GetFromJsonAsync<List<FılmlerM>>(UrlHelper.FılmUrl);

                return sonuc;
            //var response= await httpClient.GetAsync(UrlHelper.FılmUrl);
            //if (response.IsSuccessStatusCode)
            //{
            //    string jsonContent= await response.Content.ReadAsStringAsync();
            //    var sonuc = JsonSerializer.Deserialize<List<FılmlerM>>(jsonContent,jsonSerializerOptions);
            //    return sonuc;

            //}
            //return new List<FılmlerM>();
        }
        public async Task<List<KullanıcılarM>> GetKullanıcılarMs()
        {
            var kullanıcıGetir = await httpClient.GetFromJsonAsync<List<KullanıcılarM>>(UrlHelper.KullanıcıUrl);
            return kullanıcıGetir;
        }

            

        public async Task Sil(Guid kullanıcıId)
        {

            var url = UrlHelper.KullanıcıUrl + $"/{kullanıcıId}";
            await httpClient.DeleteAsync(url);
        }

        
    }
}
