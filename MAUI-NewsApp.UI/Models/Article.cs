using MAUI_NewsApp.Data.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.Models
{
    public class Article
    {
        [PrimaryKey]
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ImageURL { get; set; }

        public List<string> Categories { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime? BookmarkedAt { get; set; }

        public static Article FromDTO(ArticleDTO dto) => new()
        {
            ArticleId = dto.ArticleId,
            Title = dto.Title,
            Description = dto.Description,
            Link = dto.Link,
            ImageURL = dto.ImageURL,
            Categories = dto.Category,
            PublishedAt = dto.PublishedAt ?? null
        };

    }
}
