using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.Data.Services;
using MAUI_NewsApp.UI.Models;
using System.Collections.ObjectModel;

namespace MAUI_NewsApp.UI.ViewModels.Base
{
    public abstract partial class ArticlesListingViewModelBase : BaseViewModel
    {
        private readonly INewsService newsService;


        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        private string nextPage;

        public ObservableCollection<Article> Articles { get; } = new ObservableCollection<Article>();

        protected ArticlesListingViewModelBase(INewsService newsService)
        {
            this.newsService = newsService;
        }

        protected async Task LoadArticles(string category = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Articles.Clear();
            var result = await newsService.GetArticles(category: category, country: "ro", language: "ro");
            nextPage = result.NextPage;
            foreach (var article in result.Articles)
            {
                Articles.Add(Article.FromDTO(article));
            }
            IsBusy = false;
        }

        protected async Task LoadNextArticles(string category = null)
        {
            if (IsBusy || nextPage == null || IsRefreshing)
                return;

            IsBusy = true;
            var result = await newsService.GetArticles(nextPage, category: category, country: "ro", language: "ro");
            nextPage = result.NextPage;
            foreach (var article in result.Articles)
            {
                var a = Article.FromDTO(article);
                if (a.ImageURL == null)
                {
                    a.ImageURL = "placeholder.png";
                }
                Articles.Add(a);
            }
            IsBusy = false;
        }

        protected async Task RefreshArticles(string category = null)
        {
            if (IsBusy)
                return;

            IsRefreshing = true;
            await LoadArticles(category);
            IsRefreshing = false;
        }

        [RelayCommand]
        private async Task OpenArticle(Article article)
        {
            var query = new Dictionary<string, object>
        {
            { "article", article }
        };

            await Shell.Current.GoToAsync("ArticlePage", query);
        }
    }
}
