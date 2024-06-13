using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_NewsApp.UI.Models;


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
    }
}
