using MAUI_NewsApp.UI.Models;

namespace MAUI_NewsApp.UI.ViewModels
{
    public interface IHomeViewModel
    {
        public ICollection<Article> Articles { get; }
    }
}
