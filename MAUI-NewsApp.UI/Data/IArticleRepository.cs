using MAUI_NewsApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.Data
{
    public interface IArticleRepository
    {
        Task BookmarkArticleAsync(Article article);
        Task<List<Article>> GetBookmarkedArticles();

        Task RemoveBookmark(Article article);

        Task<bool> IsBookmarked(Article article);
    }
}
