using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.UI.Models;
using MAUI_NewsApp.UI.Utils;


namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel, ICategoriesViewModel
    {
        private ICollection<Category> categories;
        public ICollection<Category> Categories => categories;

        public CategoriesViewModel()
        {
            categories = new List<Category>()
            {
                new Category("Business", MaterialIcons.Business),
                new Category("Crime", MaterialIcons.Gavel),
                new Category("Domestic", MaterialIcons.Home),
                new Category("Education", MaterialIcons.School),
                new Category("Entertainment", MaterialIcons.Movie),
                new Category("Environment", MaterialIcons.Nature),
                new Category("Food", MaterialIcons.Fastfood),
                new Category("Health", MaterialIcons.LocalHospital),
                new Category("Lifestyle", MaterialIcons.SelfImprovement),
                new Category("Other", MaterialIcons.Category),
                new Category("Politics", MaterialIcons.AccountBalance),
                new Category("Science", MaterialIcons.Science),
                new Category("Sports", MaterialIcons.Sports),
                new Category("Technology", MaterialIcons.Computer),
                new Category("Tourism", MaterialIcons.Flight),
                new Category("World", MaterialIcons.Public)
            };
        }


        [RelayCommand]
        private async Task OpenCategoryArticles(Category category)
        {
            var query = new Dictionary<string, object>()
            {
                { "category", category }
            };

            await Shell.Current.GoToAsync("CategoryPage", query);
        }


    }
}
