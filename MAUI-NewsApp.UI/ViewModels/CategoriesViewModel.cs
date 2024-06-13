using MAUI_NewsApp.Data.DTO;
using MAUI_NewsApp.Data.Services;
using MAUI_NewsApp.Data.Utils;
using MAUI_NewsApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public class CategoriesViewModel : BaseViewModel, ICategoriesViewModel
    {
        private readonly INewsService newsService;
        private ICollection<Category> categories;

        public CategoriesViewModel(INewsService newsService)
        {
            this.newsService = newsService;

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

        public ICollection<Category> Categories => categories;
    }
}
