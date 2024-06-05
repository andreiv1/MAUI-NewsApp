using MAUI_NewsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public interface ICategoriesViewModel
    {
        public ICollection<Category> Categories { get; }
    }
}
