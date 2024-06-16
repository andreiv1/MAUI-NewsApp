using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.UI.Data;
using MAUI_NewsApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class BookmarksViewModel : BaseViewModel, IBookmarksViewModel
    {
        private readonly IArticleRepository articleRepository;

        public ObservableCollection<Article> BookmarkedArticles { get; private set; } = new();

        public BookmarksViewModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task LoadBookmarkedArticles()
        {
            BookmarkedArticles.Clear();
            var articles = await articleRepository.GetBookmarkedArticles();
            foreach (var article in articles)
            {
                BookmarkedArticles.Add(article);
            }
        }

        [RelayCommand]
        private async Task OpenArticle(Article article)
        {
            var query = new Dictionary<string, object>()
            {
                { "article", article }
            };

            await Shell.Current.GoToAsync("ArticlePage", query);
        }
    }
}
