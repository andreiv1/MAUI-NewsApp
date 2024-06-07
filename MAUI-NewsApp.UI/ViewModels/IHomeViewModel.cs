using MAUI_NewsApp.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public interface IHomeViewModel
    {
        public ICollection<Article> LatestArticles { get; }
    }
}
