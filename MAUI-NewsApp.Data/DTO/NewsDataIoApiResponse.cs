using Newtonsoft.Json;

namespace MAUI_NewsApp.Data.DTO
{
    public class NewsDataIoApiResponse
    {
        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("results")]
        public List<Article>? Results { get; set; }

        [JsonProperty("nextPage")]
        public string? NextPage { get; set; }
    }
}
