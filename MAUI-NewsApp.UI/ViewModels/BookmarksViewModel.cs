using MAUI_NewsApp.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public class BookmarksViewModel : IBookmarksViewModel
    {
        private readonly IArticleRepository articleRepository;

        public BookmarksViewModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
    }
}
