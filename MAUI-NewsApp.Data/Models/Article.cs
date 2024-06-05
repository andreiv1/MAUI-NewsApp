using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.Data.Models
{
    public class Article
    {
        public string? ArticleId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public string? ImageURL { get; set; }
        public string? Category { get; set; }
        public DateTime? PublishedAt { get; set; }

        public Article(string articleId, string title, string description, string link, string imageURL, string category, DateTime publishedAt)
        {
            this.ArticleId = articleId;
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.ImageURL = imageURL;
            this.Category = category;
            this.PublishedAt = publishedAt;
        }

    }
}
