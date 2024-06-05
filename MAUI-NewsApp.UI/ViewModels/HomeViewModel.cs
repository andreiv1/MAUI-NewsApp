using MAUI_NewsApp.Data.Models;
using MAUI_NewsApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public class HomeViewModel : IHomeViewModel
    {
        public HomeViewModel(INewsService newsService)
        {
            this.Keywords = newsService.GetKeywords();
            this.LatestArticles = newsService.GetLatestArticles();

            foreach(var k in Keywords)
            {
                Debug.WriteLine(k);
            }
        }

        public ICollection<string> Keywords { get; private set; }
        public ICollection<Article> LatestArticles { get; private set; }
    }
}
