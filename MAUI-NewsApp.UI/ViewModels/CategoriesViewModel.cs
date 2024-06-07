using MAUI_NewsApp.Data.DTO;
using MAUI_NewsApp.Data.Services;
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

        public CategoriesViewModel(INewsService newsService)
        {
            this.newsService = newsService;

            Task.Run(() => LoadCategories());
        }

        public async Task LoadCategories()
        {
            Categories = await newsService.GetCategories();
        }
        public ICollection<Category> Categories { get; private set; }


    }
}
