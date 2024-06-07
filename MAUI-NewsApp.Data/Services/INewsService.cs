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
        public Task<ICollection<string>> GetKeywords();
        public Task<ICollection<Category>> GetCategories();
        public Task<ICollection<Article>> GetLatestArticles();
        public Task<ICollection<Article>> GetArticlesByCategory(string category);
        public Task<ICollection<Article>> GetArticlesByTag(string tag);
    }
}
