using MAUI_NewsApp.UI.ViewModels;

namespace MAUI_NewsApp.UI.Views;

public partial class ArticlePage : ContentPage
{
	public ArticlePage(IArticleViewModel articleViewModel)
	{
		InitializeComponent();
		this.BindingContext = articleViewModel;
	}
}