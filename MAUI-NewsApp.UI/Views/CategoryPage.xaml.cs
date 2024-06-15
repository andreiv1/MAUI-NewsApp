
using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.ViewModels;

namespace MAUI_NewsApp.UI.Views;

public partial class CategoryPage : ContentPage, IQueryAttributable
{
	public CategoryPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.FirstOrDefault(a => a.Key.Equals("category")).Value is Category c)
        {
            //TODO - no dependency injection here
            this.BindingContext = new CategoryViewModel(c);
        }
    }
}