using MAUI_NewsApp.UI.Models;
using SQLite;

namespace MAUI_NewsApp.UI.Data
{
    public class ArticleRepository : IArticleRepository
    {
        const string name = "ArticleDb.db";

        private SQLiteAsyncConnection connection;
        
        private async Task Initialize()
        {
            if (connection == null)
            {
                var path = Path.Combine(FileSystem.AppDataDirectory, name);
                var flags = SQLite.SQLiteOpenFlags.ReadWrite
                    | SQLite.SQLiteOpenFlags.Create
                    | SQLite.SQLiteOpenFlags.SharedCache;
                connection = new SQLiteAsyncConnection(path, flags);
                await connection.CreateTableAsync<Article>();
            }
        }
        
        public async Task BookmarkArticleAsync(Article article)
        {
            await Initialize();
            await connection.InsertAsync(article);
        }

        public async Task<List<Article>> GetBookmarkedArticles()
        {
            await Initialize();
            return await connection.Table<Article>()
                .OrderBy(a => a.BookmarkedAt)
                .ToListAsync();
        }

        public async Task RemoveBookmark(Article article)
        {
            await Initialize();
            await connection.DeleteAsync(article);
        }
    }
}
