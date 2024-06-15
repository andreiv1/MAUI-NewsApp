using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.Data.Services;
using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private readonly INewsService newsService;

        [ObservableProperty]
        bool isBusy = false;

        [ObservableProperty]
        bool isRefreshing = false;

        private string nextPage;

        public HomeViewModel(INewsService newsService)
        {
            this.newsService = newsService;

            _ = LoadLatestArticles();
        }

        public ICollection<Article> Articles { get; private set; } = new ObservableCollection<Article>();

        private async Task LoadLatestArticles()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var result = await newsService.GetArticles(country: "ro", language: "ro");
            nextPage = result.NextPage;
            foreach (var article in result.Articles)
            {
                Articles.Add(Article.FromDTO(article));
            }
            IsBusy = false;
        }

        [RelayCommand]
        private async Task LoadNextArticles()
        {
            if (IsBusy || nextPage == null || IsRefreshing)
                return;

            IsBusy = true;
            var result = await newsService.GetArticles(nextPage, country: "ro", language: "ro");
            nextPage = result.NextPage;
            foreach (var article in result.Articles)
            {
                Articles.Add(Article.FromDTO(article));
            }
            IsBusy = false;
        }

        [RelayCommand]
        private async Task RefreshArticles()
        {
            Debug.WriteLine("Refreshing articles...");
            if(IsBusy)
                return;

            Articles.Clear();
            nextPage = null;
            var result = await newsService.GetArticles(country: "ro", language: "ro");
            nextPage = result.NextPage;
            foreach (var article in result.Articles)
            {
                Articles.Add(Article.FromDTO(article));
            }

            IsRefreshing = false;

        }

        [RelayCommand]
        private async Task OpenArticle(Article article)
        {
            Debug.WriteLine($"Opening article: {article.Title}");

            var query = new Dictionary<string, object>()
            {
                { "article", article }
            };

            await Shell.Current.GoToAsync("ArticlePage", query);
        }

        
    }
}
