using System;
using System.Collections.Generic;
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
using SQLite;
using System.IO;
using System.Collections.ObjectModel;

namespace SQL
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ObservableCollection<lib> seznamAut = new ObservableCollection<lib>();
        public MainWindow()
        {
            InitializeComponent();

            listView.ItemsSource = seznamAut;

            try
            {
                var databasePath = "MyData.db";

                var conn = new SQLiteConnection(databasePath);
                if (conn != null)
                {
                    var query = conn.Table<lib>();

                    foreach (var misc in query)
                    {
                        seznamAut.Add(misc);
                    }
                }
            } catch(Exception)
            {
                var databasePath = "MyData.db";

                var conn = new SQLiteConnection(databasePath);
                conn.CreateTable<lib>();
            }

        }

        private void Age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string NameInput = Name.Text;
            int PowerInput = Int32.Parse(Power.Text);
            string ManuInput = Manufacturer.Text;
            string CondInput = Cond.Text;

            lib auto = new lib()
            {
                Name = NameInput,
                Power = PowerInput,
                Cond = CondInput,
                Manu = ManuInput
            };

            var databasePath = "MyData.db";
            var db = new SQLiteConnection(databasePath);
            //ManuInput + " " +NameInput + " | " + PowerInput + " kW | " + CondInput
            seznamAut.Add(auto);
            lib.add(db, NameInput, PowerInput, CondInput, ManuInput);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var databasePath = "MyData.db";

            var conn = new SQLiteConnection(databasePath);

            lib item = (lib)listView.SelectedItem;
            conn.Delete(item);
            seznamAut.Remove(item);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void listView_Selected(object sender, RoutedEventArgs e)
        {
            ListView seznam = (ListView)sender;
            lib jednoAuto = (lib)seznam.SelectedItem;

            Name.Text = jednoAuto.Name;
            Power.Text = jednoAuto.Power;
            string ManuInput = jednoAuto.Manu;
            string CondInput = jednoAuto.Cond;

        }
    }
}
