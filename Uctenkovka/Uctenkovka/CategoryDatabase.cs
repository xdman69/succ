using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uctenkovka
{
    public class CategoryDatabase
    {
        private SQLiteAsyncConnection database;

        public CategoryDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Category>().Wait();
        }


        public Task<List<Category>> GetItemsAsync()
        {
            return database.Table<Category>().ToListAsync();
        }

        public Task<List<Category>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Category>("SELECT * FROM [Category] WHERE [Done] = 0");
        }

        public Task<Category> GetItemAsync(int id)
        {
            return database.Table<Category>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Category item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Category item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteItem(int id)
        {
            return database.ExecuteAsync("delete from [Category] where ID='" + id + "'");
        }
    }
}
