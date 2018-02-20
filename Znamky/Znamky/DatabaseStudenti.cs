using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Znamky
{
    class DatabaseStudenti
    {
        private SQLiteAsyncConnection database;

        public DatabaseStudenti(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Studenti>().Wait();
        }


        public Task<List<Studenti>> GetItemsAsync()
        {
            return database.Table<Studenti>().ToListAsync();
        }

        public Task<List<Studenti>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Studenti>("SELECT * FROM [Studenti] WHERE [Done] = 0");
        }

        public Task<Studenti> GetItemAsync(int id)
        {
            return database.Table<Studenti>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Studenti item)
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

        public Task<int> DeleteItemAsync(Studenti item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteItems()
        {
            return database.ExecuteAsync("DELETE FROM [Studenti]");
        }
    }
}
