﻿using MAUI_NewsApp.Data.DTO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Web;

namespace MAUI_NewsApp.Data.Services
{
    public class NewsDataIoService : INewsService
    {
        private const string apiKey = "pub_46532bd1c9909d0d04f247db9bee28f97b723";
        private const string apiBaseUrl = $"https://newsdata.io/api/1/news";
        private readonly HttpClient httpClient = new();

        public async Task<ArticleResult> GetArticles(string? page = null, string? category = null, string? country = null, string? language = null)
        {
            var builder = new UriBuilder(apiBaseUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["apikey"] = apiKey;

            if (page != null)
            {
                query["page"] = page;
            }

            if (category != null)
            {
                query["category"] = category;
            }

            if (country != null)
            {
                query["country"] = country;
            }

            if (language != null)
            {
                query["language"] = language;
            }

            builder.Query = query.ToString();
            var apiUrl = builder.ToString();

            // Fetch articles from API
            var response = await httpClient.GetAsync(apiUrl);
            Debug.WriteLine($"Status Code: {response.StatusCode}");

            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine($"Failed to fetch articles: {response.ReasonPhrase}");
                return new ArticleResult()
                {
                    Articles = new List<ArticleDTO>(),
                };
            }

            var json = await response.Content.ReadAsStringAsync();

            Debug.WriteLine($"JSON Response: {json}");
            Debug.WriteLine("Trying to deserialize JSON...");
            try
            {
                var data = JsonConvert.DeserializeObject<NewsDataIoApiResponse>(json);
                Debug.WriteLine($"Convert: {data?.Status} {data?.Results?.Count ?? -1}");
                return new ArticleResult()
                {
                    Articles = data?.Results ?? new List<ArticleDTO>(),
                    NextPage = data?.NextPage,
                };
               
            }
            catch (JsonSerializationException ex)
            {
                Debug.WriteLine($"Failed to deserialize JSON: {ex.Message}");
                return new ArticleResult()
                {
                    Articles = new List<ArticleDTO>(),
                };

            }
        }
    }
}
