using CommunityToolkit.Mvvm.Input;
using MAUI_NewsApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI_NewsApp.UI.ViewModels
{
    public interface IArticleViewModel
    {
        public Article Article { get; set; }
        public ICommand OpenLinkCommand { get; }
    }
}
