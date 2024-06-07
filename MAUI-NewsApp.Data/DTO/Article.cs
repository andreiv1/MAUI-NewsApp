using Newtonsoft.Json;

namespace MAUI_NewsApp.Data.DTO
{
    public class Article
    {
        [JsonProperty("article_id")]
        public string? ArticleId { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("link")]
        public string? Link { get; set; }

        [JsonProperty("image_url")]
        public string? ImageURL { get; set; }

        [JsonProperty("category")]
        public List<string>? Category { get; set; }

        [JsonProperty("pubDate")]
        public DateTime? PublishedAt { get; set; }
    }
}
