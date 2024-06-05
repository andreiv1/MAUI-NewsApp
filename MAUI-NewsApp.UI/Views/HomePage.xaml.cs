using MAUI_NewsApp.UI.ViewModels;

namespace MAUI_NewsApp.UI.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IHomeViewModel homeViewModel)
	{
		InitializeComponent();
		this.BindingContext = homeViewModel;
	}
}