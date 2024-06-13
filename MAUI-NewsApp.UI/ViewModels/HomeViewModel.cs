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

        public HomeViewModel(INewsService newsService)
        {
            this.newsService = newsService;

            Task.Run(async () =>
            {
                await LoadLatestArticles();
            });
        }

        private async Task LoadLatestArticles()
        {
            foreach(var article in await newsService.GetLatestArticles())
            {
                Articles.Add(Article.FromDTO(article));
            }
        }

        public ICollection<Article> Articles { get; private set; } = new ObservableCollection<Article>();

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
