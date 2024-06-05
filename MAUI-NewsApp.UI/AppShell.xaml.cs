namespace MAUI_NewsApp.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            SetTabsIcons();
        }

        public void SetTabsIcons()
        {
            this.HomeTab.Icon = ImageSource.FromResource("MAUI_NewsApp.UI.Resources.Images.home.png", this.GetType().Assembly);
            this.CategoriesPage.Icon = ImageSource.FromResource("MAUI_NewsApp.UI.Resources.Images.categories.png", this.GetType().Assembly);
            this.BookmarksTab.Icon = ImageSource.FromResource("MAUI_NewsApp.UI.Resources.Images.bookmarks.png", this.GetType().Assembly);
        }
    }
}
