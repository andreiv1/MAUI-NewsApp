using MAUI_NewsApp.Data.Models;
using MAUI_NewsApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public class CategoriesViewModel : ICategoriesViewModel
    {
        public CategoriesViewModel(INewsService newsService)
        {
           Categories = newsService.GetCategories();
        }
        public ICollection<Category> Categories { get; private set; }


    }
}
