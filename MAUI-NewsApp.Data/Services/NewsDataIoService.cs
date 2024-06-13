using MAUI_NewsApp.Data.DTO;
using MAUI_NewsApp.Data.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.Data.Services
{
    public class NewsDataIoService : INewsService
    {
        private const string apiKey = "pub_45307ca710cbce55937751cdb329b85a276fe";
        private const string apiUrl = $"https://newsdata.io/api/1/news?apikey={apiKey}";
        private readonly HttpClient httpClient = new();

        public Task<ICollection<ArticleDTO>> GetArticlesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ArticleDTO>> GetArticlesByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ArticleDTO>> GetLatestArticles()
        {
            //TODO: Treat the case when the API is down

            var response = await httpClient.GetAsync($"{apiUrl}&country=ro&language=ro");

            // Log the status code to ensure the request was successful
            Debug.WriteLine($"Status Code: {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Failed to fetch articles: {response.ReasonPhrase}");
                return new List<ArticleDTO>();
            }

            var json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"JSON Response: {json}");
            Debug.WriteLine("Trying to deserialize JSON...");
            try
            {
                var data = JsonConvert.DeserializeObject<NewsDataIoApiResponse>(json);
                Debug.WriteLine($"Convert: {data?.Status} {data?.Results?.Count ?? -1}");
                return data?.Results ?? new List<ArticleDTO>();
            }
            catch(JsonSerializationException ex)
            {
                Debug.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                return new List<ArticleDTO>();
            }
           
        }
    }
}
