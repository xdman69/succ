using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        ObservableCollection<Expense> exCol = new ObservableCollection<Expense>();
        ObservableCollection<Category> catCol = new ObservableCollection<Category>();
        ObservableCollection<Debt> debtCol = new ObservableCollection<Debt>();

        DateTime today = DateTime.Today;
        private static ExpenseDatabase _database;
        private static ExpenseDatabase Database
        {
            get
            {
                if(_database == null)
                {
                    _database = new ExpenseDatabase(@"D:\valesja15\GIT\Uctenkovka\Expense.db");
                }
                return _database;
            }
        }

        private static CategoryDatabase _databaseCat;
        private static CategoryDatabase DatabaseCat
        {
            get
            {
                if (_databaseCat == null)
                {
                    _databaseCat = new CategoryDatabase(@"D:\valesja15\GIT\Uctenkovka\Category.db");
                }
                return _databaseCat;
            }
        }

        private static DebtDatabase _databaseDebt;
        private static DebtDatabase DatabaseDebt
        {
            get
            {
                if (_databaseDebt == null)
                {
                    _databaseDebt = new DebtDatabase(@"D:\valesja15\GIT\Uctenkovka\Debt.db");
                }
                return _databaseDebt;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var itemsFromDb = Database.GetItemsAsync().Result;
            var itemsCatFromDb = DatabaseCat.GetItemsAsync().Result;
            var itemsDebtFromDb = DatabaseDebt.GetItemsAsync().Result;
            now.Text = "Celková útrata za " + itemsFromDb.Count + " položek ke dni " + today.ToString("dd/MM/");
            int suma = 0;
            foreach (var data in itemsFromDb)
            {
                suma = suma + data.Price;
                sum.Text = suma.ToString();
            }
            if(itemsFromDb.Count == 0)
            {
                now.Text = "Žádná položka v seznamu";
            }
            int overduePrice = 0;
            foreach (var data in itemsDebtFromDb)
            {
                int result = DateTime.Compare(today.Date, Convert.ToDateTime(data.Date));
                //debtCount.Text = "Dluh celkem: " + data.Price;
                if (result >= 1)
                {
                    overduePrice += data.Price;
                    debtDue.Text = "Dluh přesčas: " + overduePrice;
                }
            }
            catCount.Text = "Počet kategorií: " + itemsCatFromDb.Count.ToString();
        }

        public Past()
        {
            InitializeComponent();

            var itemsFromDb = Database.GetItemsAsync().Result;
            var itemsCatFromDb = DatabaseCat.GetItemsAsync().Result;
            var itemsDebtFromDb = DatabaseDebt.GetItemsAsync().Result;
            catList.ItemsSource = itemsCatFromDb;
            debtList.ItemsSource = itemsDebtFromDb;
            expensesList.ItemsSource = itemsFromDb;
            catCombo.ItemsSource = itemsCatFromDb;
            catPriceCombo.ItemsSource = itemsCatFromDb;
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
            item.Category = catCombo.Text;
            
            Database.SaveItemAsync(item);
            exCol.Add(item);
            var itemsFromDb = Database.GetItemsAsync().Result;

            expensesList.ItemsSource = exCol;
            int suma = 0;
            now.Text = "Celková útrata za "+ itemsFromDb.Count + " položek ke dni " + today.ToString("dd/MM/") + " ";
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

            exCol.Remove(item);
            await Database.DeleteItemAsync(item);

            var itemsFromDb = Database.GetItemsAsync().Result;
            expensesList.ItemsSource = itemsFromDb;

            now.Text = "Celková útrata za " + itemsFromDb.Count + " položek ke dni " + today.ToString("dd/MM/") + " ";
            int suma = 0;
            foreach (var data in itemsFromDb)
            {
                suma = suma + data.Price;
                sum.Text = suma.ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dbConnection = DatabaseCat;

            CategoryDatabase produktDatabase = DatabaseCat;

            Category item = new Category();
            string name = newCat.Text;
            item.Name = name;

            DatabaseCat.SaveItemAsync(item);
            catCol.Add(item);
            var itemsFromDb = DatabaseCat.GetItemsAsync().Result;

            catList.ItemsSource = catCol;

            catCombo.ItemsSource = catCol;

            catPriceCombo.ItemsSource = catCol;

            catCount.Text = "Počet kategorií: " + itemsFromDb.Count.ToString();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var id = catList.SelectedIndex;

            var item = (Category)catList.SelectedItem;

            catCol.Remove(item);
            await DatabaseCat.DeleteItemAsync(item);

            var itemsFromDb = DatabaseCat.GetItemsAsync().Result;
            catList.ItemsSource = itemsFromDb;
            catCombo.ItemsSource = itemsFromDb;
            catPriceCombo.ItemsSource = itemsFromDb;

            catCount.Text = "Počet kategorií: " + itemsFromDb.Count.ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var dbConnection = DatabaseCat;
            var itemsFromDb = Database.GetItemsAsync().Result;
            var itemsCatFromDb = DatabaseCat.GetItemsAsync().Result;
            int suma = 0;
            List<Expense> list = new List<Expense>();
            List<Category> listCat = new List<Category>();
            foreach (var data in itemsFromDb)
            {
                if (data.Category == catPriceCombo.Text)
                {
                    suma = suma + data.Price;
                    list.Add(data);
                }
            }
            foreach (var data in itemsCatFromDb)
            {
                if (data.Name == catPriceCombo.Text)
                {
                    listCat.Add(data);
                }
            }
            catCount.Text = "Vybírají se položky z kategorie " + catPriceCombo.Text;
            catList.ItemsSource = listCat;
            expensesList.ItemsSource = list;
            catPrice.Text = "Útrata za kategorii "+ catPriceCombo.Text + " je " + suma.ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var dbConnection = DatabaseCat;
            var itemsFromDb = Database.GetItemsAsync().Result;
            int suma = 0;
            List<Expense> list = new List<Expense>();
            foreach (var data in itemsFromDb)
            {
                if (data.Date == datePrice.Text)
                {
                    suma = suma + data.Price;
                    list.Add(data);
                }
            }

            expensesList.ItemsSource = list;
            dayPrice.Text = "Útrata za den " + datePrice.Text + " je " + suma.ToString();
        }

        private void priceText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            var dbConnectionCat = DatabaseCat;
            var dbConnection = Database;
            var itemsFromDb = Database.GetItemsAsync().Result;
            var itemsCatFromDb = DatabaseCat.GetItemsAsync().Result;

            catList.ItemsSource = itemsCatFromDb;
            expensesList.ItemsSource = itemsFromDb;

            catCount.Text = "Počet kategorií: " + itemsCatFromDb.Count.ToString();

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var dbConnection = DatabaseDebt;

            DebtDatabase produktDatabase = DatabaseDebt;

            Debt item = new Debt();
            string name = nameDebt.Text;
            string price = newDebt.Text;
            string date = dateDebt.Text;

            int x = Int32.Parse(price);
            item.Price = x;
            item.Date = date;
            item.Name = name;
           

            DatabaseDebt.SaveItemAsync(item);
            debtCol.Add(item);
            var itemsFromDb = DatabaseDebt.GetItemsAsync().Result;

            debtList.ItemsSource = debtCol;
            int overduePrice = 0;
            foreach (var data in itemsFromDb)
            {
                int result = DateTime.Compare(today.Date, Convert.ToDateTime(data.Date));
                //debtCount.Text = "Dluh celkem: " + data.Price;
                if (result >= 1)
                {
                    overduePrice += data.Price;
                    debtDue.Text = "Dluh přesčas: " + overduePrice;
                }
            }
        }

        private async void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var id = debtList.SelectedIndex;

            var item = (Debt)debtList.SelectedItem;

            debtCol.Remove(item);
            await DatabaseDebt.DeleteItemAsync(item);

            var itemsFromDb = DatabaseDebt.GetItemsAsync().Result;
            debtList.ItemsSource = itemsFromDb;
            int overduePrice = 0;
            foreach (var data in itemsFromDb)
            {
                int result = DateTime.Compare(today.Date, Convert.ToDateTime(data.Date));
                //debtCount.Text = "Dluh celkem: " + data.Price;
                if (result >= 1)
                {
                    overduePrice += data.Price;
                    debtDue.Text = "Dluh přesčas: " + overduePrice;
                }
            }
        }
    }
}
