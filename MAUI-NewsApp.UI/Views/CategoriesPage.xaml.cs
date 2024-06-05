using MAUI_NewsApp.UI.ViewModels;

namespace MAUI_NewsApp.UI.Views;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage(ICategoriesViewModel categoriesViewModel)
	{
		InitializeComponent();
		this.BindingContext = categoriesViewModel;
	}
}