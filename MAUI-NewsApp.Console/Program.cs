using MAUI_NewsApp.Data.Services;

namespace MAUI_NewsApp.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
           INewsService newsService = new NewsDataIoService();

           var articles = newsService.GetLatestArticles().Result;

           foreach(var article in articles)
            {
               System.Console.WriteLine(article.Title);
           }
        }
    }
}
