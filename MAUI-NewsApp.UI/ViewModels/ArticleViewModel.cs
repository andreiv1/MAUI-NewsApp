using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.UI.Models;
using System.Windows.Input;


namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class ArticleViewModel : BaseViewModel, IArticleViewModel
    {
        public ArticleViewModel()
        {
        }
        public ArticleViewModel(Article article)
        {
            Article = article;
        }

        public Article Article { get; }

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
