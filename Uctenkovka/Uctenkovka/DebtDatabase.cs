using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uctenkovka
{
    class DebtDatabase
    {
        private SQLiteAsyncConnection database;

        public DebtDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Debt>().Wait();
        }


        public Task<List<Debt>> GetItemsAsync()
        {
            return database.Table<Debt>().ToListAsync();
        }

        public Task<List<Debt>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Debt>("SELECT * FROM [Debt] WHERE [Done] = 0");
        }

        public Task<Debt> GetItemAsync(int id)
        {
            return database.Table<Debt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Debt item)
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

        public Task<int> DeleteItemAsync(Debt item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteItem(int id)
        {
            return database.ExecuteAsync("delete from [Debt] where ID='" + id + "'");
        }
    }
}
