using MAUI_NewsApp.Data.Models;
using MAUI_NewsApp.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_NewsApp.Data.Services
{
    public class DummyService : INewsService
    {
        public ICollection<Article> GetArticlesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public ICollection<Article> GetArticlesByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category("Business", MaterialIcons.Business),
                new Category("Crime", MaterialIcons.Gavel),
                new Category("Domestic", MaterialIcons.Home),
                new Category("Education", MaterialIcons.School),
                new Category("Entertainment", MaterialIcons.Movie),
                new Category("Environment", MaterialIcons.Nature),
                new Category("Food", MaterialIcons.Fastfood),
                new Category("Health", MaterialIcons.LocalHospital),
                new Category("Lifestyle", MaterialIcons.SelfImprovement),
                new Category("Other", MaterialIcons.Category),
                new Category("Politics", MaterialIcons.AccountBalance),
                new Category("Science", MaterialIcons.Science),
                new Category("Sports", MaterialIcons.Sports),
                new Category("Technology", MaterialIcons.Computer),
                new Category("Tourism", MaterialIcons.Flight),
                new Category("World", MaterialIcons.Public)
            };
        }

        public ICollection<Article> GetLatestArticles()
        {
            return new List<Article>()
            {
                 new Article("001",
                    "Massa ultricies mi quis hendrerit dolor magna eget.",
                    "Ut venenatis tellus in metus vulputate eu. Enim neque volutpat ac tincidunt vitae semper quis.",
                    "https://www.google.com",
                    "https://picsum.photos/seed/one/300/200",
                    "Business", DateTime.Now),
                new Article("002",
                    "Auctor elit sed vulputate mi sit amet mauris.",
                    "Habitasse platea dictumst vestibulum rhoncus est. Et ligula ullamcorper malesuada proin libero nunc.",
                    "https://www.google.com",
                    "https://picsum.photos/seed/three/300/200",
                    "Sports", DateTime.Now),
                new Article("003",
                    "Nibh venenatis cras sed felis eget velit aliquet.",
                    "Sollicitudin ac orci phasellus egestas. Nulla facilisi cras fermentum odio eu feugiat pretium nibh.",
                    "https://www.google.com",
                    "https://picsum.photos/seed/two/300/200",
                    "Science", DateTime.Now),
                new Article("004",
                    "Massa tempor nec feugiat nisl pretium fusce.",
                    "Tellus in metus vulputate eu scelerisque felis imperdiet. Orci eu lobortis elementum nibh tellus molestie nunc non blandit.",
                    "https://www.google.com",
                    "https://picsum.photos/seed/four/300/200",
                    "Politics",  DateTime.Now)
            };
        }

        public ICollection<string> GetKeywords()
        {
            return new List<string>
            {
                "politics",
                "elections",
                "world",
                "lifestyle",
                "marketing",
                "climate",
                "trending",
                "celebrity",
            };
        }
    }
}
