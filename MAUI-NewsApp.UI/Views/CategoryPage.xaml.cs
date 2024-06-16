
using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.ViewModels;

namespace MAUI_NewsApp.UI.Views;

public partial class CategoryPage : ContentPage, IQueryAttributable
{
    private readonly ICategoryViewModel viewModel;

    public CategoryPage(ICategoryViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.FirstOrDefault(a => a.Key.Equals("category")).Value is Category c)
        {
            this.BindingContext = viewModel;
            viewModel.Category = c;
            
        }
    }
}