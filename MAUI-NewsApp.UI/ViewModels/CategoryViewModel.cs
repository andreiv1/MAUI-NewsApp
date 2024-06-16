using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.Data.Services;
using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class CategoryViewModel : BaseViewModel, ICategoryViewModel
    {
        public ObservableCollection<Article> Articles { get; } = new ObservableCollection<Article>();

        private Category category;

        public Category Category
        {
            get => category;
            set
            {
                if (SetProperty(ref category, value))
                {
                    CategoryName = category.Name;
                    _ = LoadArticles();
                }
            }
        }

        [ObservableProperty]
        bool isBusy = false;

        [ObservableProperty]
        bool isRefreshing = false;

        [ObservableProperty]
        private string categoryName;
        private string nextPage;
        private readonly INewsService newsService;

        public CategoryViewModel(INewsService newsService) 
        {
            this.newsService = newsService;
        }

        private async Task LoadArticles()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            var result = await newsService.GetArticles(category: CategoryName, country: "ro", language: "ro");
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
            var result = await newsService.GetArticles(nextPage, CategoryName, country: "ro", language: "ro");
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
            if (IsBusy)
                return;

            Articles.Clear();
            nextPage = null;
            var result = await newsService.GetArticles(category: CategoryName, country: "ro", language: "ro");
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
