using MAUI_NewsApp.UI.Models;


namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class ArticleViewModel : BaseViewModel, IArticleViewModel
    {
        private readonly HttpClient httpClient = new();
        public ArticleViewModel()
        {
        }
        public ArticleViewModel(Article a)
        {
            this.Title = a.Title;
            this.Description = a.Description;
            this.ImageURL = a.ImageURL;
            this.Link = a.Link;
        }

        public string Title { get; }
        public string Description { get; }
        public string ImageURL { get; }
        public string Link { get; }

        public string HtmlContent { get; private set; }
    }
}
