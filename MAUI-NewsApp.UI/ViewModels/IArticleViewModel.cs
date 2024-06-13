using CommunityToolkit.Mvvm.Input;
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
        public ICommand OpenLinkCommand { get; }
    }
}
