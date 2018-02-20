using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znamky
{
    class DatabaseZnamky
    {
        private SQLiteAsyncConnection database;

        public DatabaseZnamky(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Znamky>().Wait();
        }


        public Task<List<Znamky>> GetItemsAsync()
        {
            return database.Table<Znamky>().ToListAsync();
        }

        public Task<List<Znamky>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Znamky>("SELECT * FROM [Znamky] WHERE [Done] = 0");
        }

        public Task<Znamky> GetItemAsync(int id)
        {
            return database.Table<Znamky>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Znamky item)
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

        public Task<int> DeleteItemAsync(Znamky item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteItems()
        {
            return database.ExecuteAsync("DELETE FROM [Znamky]");
        }
    }
}
