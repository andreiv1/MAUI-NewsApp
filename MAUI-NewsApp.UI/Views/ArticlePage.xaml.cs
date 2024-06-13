using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.ViewModels;
using System.Net;

namespace MAUI_NewsApp.UI.Views;

public partial class ArticlePage : ContentPage, IQueryAttributable
{
    CookieContainer cookieContainer = new CookieContainer();
	public ArticlePage(IArticleViewModel articleViewModel)
	{
		InitializeComponent();
		this.BindingContext = articleViewModel;

        //webview.Cookies = cookieContainer;
        //webview.
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.FirstOrDefault(a => a.Key.Equals("article")).Value is Article a)
        {
            //TODO - no dependency injection here
            this.BindingContext = new ArticleViewModel(a);
        }
    }
}