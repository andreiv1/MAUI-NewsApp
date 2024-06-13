using MAUI_NewsApp.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.Data.Services
{
    public interface INewsService
    {
        public Task<ICollection<ArticleDTO>> GetLatestArticles();
        public Task<ICollection<ArticleDTO>> GetArticlesByCategory(string category);
        public Task<ICollection<ArticleDTO>> GetArticlesByTag(string tag);
    }
}
