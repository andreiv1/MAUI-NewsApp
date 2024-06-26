using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.ViewModels;
using System.Net;

namespace MAUI_NewsApp.UI.Views;

public partial class ArticlePage : ContentPage, IQueryAttributable
{
    private readonly IArticleViewModel articleViewModel;

    public ArticlePage(IArticleViewModel articleViewModel)
	{
		InitializeComponent();
		this.BindingContext = articleViewModel;
        this.articleViewModel = articleViewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.FirstOrDefault(a => a.Key.Equals("article")).Value is Article a)
        {
            articleViewModel.Article = a;
            _ = SetBookmarkIcon();
        }
    }

    private async Task SetBookmarkIcon()
    {
        if (await articleViewModel.IsBookmarked())
        {
            bookmarkToolBarItem.IconImageSource = "bookmark_added_20dp.png";
        } else
        {
            bookmarkToolBarItem.IconImageSource = "bookmark_add_20dp.png";
        }
    }

    private async void bookmarkToolBarItem_Clicked(object sender, EventArgs e)
    {
        if (!await articleViewModel.IsBookmarked())
        {
            bookmarkToolBarItem.IconImageSource = "bookmark_added_20dp.png";
        }
        else
        {
            bookmarkToolBarItem.IconImageSource = "bookmark_add_20dp.png";
        }
    }
}