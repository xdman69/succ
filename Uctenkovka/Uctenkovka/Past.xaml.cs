using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uctenkovka
{
    /// <summary>
    /// Interakční logika pro Past.xaml
    /// </summary>
    ///
    public partial class Past : Page
    {
        DateTime today = DateTime.Today;
        private static ExpenseDatabase _database;
        private static ExpenseDatabase Database
        {
            get
            {
                if(_database == null)
                {
                    _database = new ExpenseDatabase("D:/valesja15/Expense.db");
                }
                return _database;
            }
        }

        public Past()
        {
            InitializeComponent();

            var itemsFromDb = Database.GetItemsAsync().Result;
            expensesList.ItemsSource = itemsFromDb;
            now.Text = today.ToString("dd/MM/");
            int suma = 0;
            foreach (var data in itemsFromDb)
            {
                suma = suma + data.Price;
                sum.Text = suma.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var dbConnection = Database;

            ExpenseDatabase produktDatabase = Database;

            Expense item = new Expense();
            string price = priceText.Text;
            string date = dateText.Text;

            int x = Int32.Parse(price);
            item.Price = x;
            item.Date = date;

            Database.SaveItemAsync(item);

            var itemsFromDb = Database.GetItemsAsync().Result;

            expensesList.ItemsSource = itemsFromDb;
            int suma = 0;
            now.Text = today.ToString("dd/MM/");
            foreach (var data in itemsFromDb)
            {
                suma = suma + data.Price;
                sum.Text = suma.ToString();
            }

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var id = expensesList.SelectedIndex;

            var item = (Expense)expensesList.SelectedItem;

            await Database.DeleteItemAsync(item);

            var itemsFromDb = Database.GetItemsAsync().Result;
            expensesList.ItemsSource = itemsFromDb;
        }
    }
}
