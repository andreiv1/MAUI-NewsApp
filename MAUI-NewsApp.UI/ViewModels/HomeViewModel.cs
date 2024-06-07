using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.Data.DTO;
using MAUI_NewsApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        [RelayCommand]
        private void NavigateToArticle(Article article)
        {
            var query = new Dictionary<string, object>()
            {
                { "article", article }
            };

            Shell.Current.GoToAsync("article", query);

        }

        private async Task LoadLatestArticles()
        {
            foreach(var article in await newsService.GetLatestArticles())
            {
                LatestArticles.Add(article);
            }
        }

        public ICollection<Article> LatestArticles { get; private set; } = new ObservableCollection<Article>();
    }
}
