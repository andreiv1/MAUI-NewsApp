using MAUI_NewsApp.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.Data.Services
{
    public class ArticleResult
    {
        public ICollection<ArticleDTO>? Articles { get; set; }
        public string? NextPage { get; set; }
    }
    public interface INewsService
    {
        /// <summary>
        /// Retrieves a collection of articles from the news API.
        /// </summary>
        /// <param name="page">The page number to retrieve. Defaults to null, which will retrieve the first page.</param>
        /// <param name="country">The country code for filtering articles. Defaults to null, which means no country filter.</param>
        /// <param name="language">The language code for filtering articles. Defaults to null, which means no language filter.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of ArticleDTO objects.</returns>
        public Task<ArticleResult> GetArticles(string? page = null, string? country = null, string? language = null);

        /// <summary>
        /// Retrieves a collection of articles from the news API filtered by the specified category.
        /// </summary>
        /// <param name="category">The category to filter articles by.</param>
        /// <param name="page">The page number to retrieve. Defaults to null, which will retrieve the first page.</param>
        /// <param name="country">The country code for filtering articles. Defaults to null, which means no country filter.</param>
        /// <param name="language">The language code for filtering articles. Defaults to null, which means no language filter.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of ArticleDTO objects.</returns>
        public Task<ArticleResult> GetArticlesByCategory(string category, string? page = null, string? country = null, string? language = null);  
    }
}
