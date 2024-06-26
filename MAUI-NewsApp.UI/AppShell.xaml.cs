﻿using MAUI_NewsApp.UI.Views;

namespace MAUI_NewsApp.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            SetTabsIcons();

            RegisterRoutes();
        }

        public void SetTabsIcons()
        {
            this.HomeTab.Icon = ImageSource.FromResource("MAUI_NewsApp.UI.Resources.Images.home.png", this.GetType().Assembly);
            this.CategoriesPage.Icon = ImageSource.FromResource("MAUI_NewsApp.UI.Resources.Images.categories.png", this.GetType().Assembly);
            this.BookmarksTab.Icon = ImageSource.FromResource("MAUI_NewsApp.UI.Resources.Images.bookmarks.png", this.GetType().Assembly);
        }

        public void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(ArticlePage), typeof(ArticlePage));
            Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
            Routing.RegisterRoute(nameof(BookmarksPage), typeof(BookmarksPage));
        }
    }
}
