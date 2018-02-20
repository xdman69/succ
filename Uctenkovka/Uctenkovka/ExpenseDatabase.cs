using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uctenkovka
{
    class ExpenseDatabase
    {
        private SQLiteAsyncConnection database;

        public ExpenseDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Expense>().Wait();
        }


        public Task<List<Expense>> GetItemsAsync()
        {
            return database.Table<Expense>().ToListAsync();
        }

        public Task<List<Expense>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Expense>("SELECT * FROM [Expense] WHERE [Done] = 0");
        }

        public Task<Expense> GetItemAsync(int id)
        {
            return database.Table<Expense>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Expense item)
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

        public Task<int> DeleteItemAsync(Expense item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteItem(int id)
        {
            return database.ExecuteAsync("delete from [Expense] where ID='" + id + "'");
        }
    }
}

