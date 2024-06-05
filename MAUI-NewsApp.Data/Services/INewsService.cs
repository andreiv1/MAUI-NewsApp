using MAUI_NewsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.Data.Services
{
    public interface INewsService
    {
        public ICollection<string> GetKeywords();
        public ICollection<Category> GetCategories();
        public ICollection<Article> GetLatestArticles();
        public ICollection<Article> GetArticlesByCategory(string category);
        public ICollection<Article> GetArticlesByTag(string tag);
    }
}
