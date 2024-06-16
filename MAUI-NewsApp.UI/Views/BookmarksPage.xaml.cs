using AndroidX.Lifecycle;
using MAUI_NewsApp.UI.ViewModels;

namespace MAUI_NewsApp.UI.Views;

public partial class BookmarksPage : ContentPage
{
    private readonly IBookmarksViewModel bookmarksViewModel;

    public BookmarksPage(IBookmarksViewModel bookmarksViewModel)
	{
		InitializeComponent();
		this.BindingContext = bookmarksViewModel;
        this.bookmarksViewModel = bookmarksViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Load or refresh data when the page appears
        _ = bookmarksViewModel.LoadBookmarkedArticles();
    }
}