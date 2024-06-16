using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.UI.Data;
using MAUI_NewsApp.UI.Models;
using System.Windows.Input;


namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class ArticleViewModel : BaseViewModel, IArticleViewModel
    {
        private readonly IArticleRepository articleRepository;
        public ArticleViewModel(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [ObservableProperty]
        private Article article;

        public ICommand OpenLinkCommand => new RelayCommand(async () =>
        {
            if (Article.Link is not null)
            {
                Uri uri = new(Article.Link);
                await Browser.Default.OpenAsync(uri);
            }
        });

        public ICommand ShareCommand => new RelayCommand(async () =>
        {
            if (Article.Link is not null)
            {
                await Share.RequestAsync(new ShareTextRequest
                {
                    Uri = Article.Link,
                    Title = Article.Title
                });
            }
        });

        public ICommand BookmarkCommand => new RelayCommand(async () =>
        {
            if (await IsBookmarked())
            {
                await articleRepository.RemoveBookmark(Article);
            }
            else
            {
                await articleRepository.BookmarkArticleAsync(Article);
            }
        });

        public async Task<bool> IsBookmarked()
        {
            return await articleRepository.IsBookmarked(Article);
        }
    }
}
