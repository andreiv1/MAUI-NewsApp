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
    }
}
