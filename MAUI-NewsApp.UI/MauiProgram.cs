using MAUI_NewsApp.Data.Services;
using MAUI_NewsApp.UI.ViewModels;
using MAUI_NewsApp.UI.Views;
using Microsoft.Extensions.Logging;

namespace MAUI_NewsApp.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterViews()
                .RegisterAppServices()
                .RegisterViewModels()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("NotoSerif-Bold.ttf", "NotoSerifBold");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemibold");
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                    fonts.AddFont("MaterialIconsOutlined-Regular.otf", "Material");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<CategoriesPage>();
            builder.Services.AddTransient<ArticlePage>();

            return builder;
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INewsService, NewsDataIoService>();

            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IHomeViewModel, HomeViewModel>();
            builder.Services.AddTransient<ICategoriesViewModel, CategoriesViewModel>();
            builder.Services.AddTransient<IArticleViewModel, ArticleViewModel>();

            return builder;
        }
    }
}
