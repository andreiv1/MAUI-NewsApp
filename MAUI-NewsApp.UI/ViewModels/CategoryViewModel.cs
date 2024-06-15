using MAUI_NewsApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; private set; }

        public CategoryViewModel(Category category)
        {
            Category = category;
        }


    }
}
