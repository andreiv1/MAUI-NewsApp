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
            
        }
    }
}