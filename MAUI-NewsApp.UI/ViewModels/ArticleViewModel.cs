using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.UI.ViewModels
{
    public partial class ArticleViewModel : BaseViewModel, IArticleViewModel
    {

        [ObservableProperty]
        private string link;

        public ArticleViewModel()
        {
        }
    }
}
