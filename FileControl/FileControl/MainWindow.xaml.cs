using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using CsvHelper;
using System.Collections;
using System.IO;
using System.Collections.ObjectModel;
using FileHelpers;

namespace FileControl
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<score> scr = new ObservableCollection<score>();
        [DelimitedRecord("|")]


        public class Orders
        {
            public string Name;

            public string Score;

        }
        public MainWindow()
        {
            InitializeComponent();
            ScoreList.ItemsSource = scr;

            var engine = new FileHelperEngine<Orders>();
            var records = engine.ReadFile(Directory.GetCurrentDirectory() + "\\data.txt");
            if (records != null)
            {
                foreach (var record in records)
                {
                    scr.Add(new score(record.Name, record.Score));
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || NumberTextBox.Text == "")
            {
                warning.Foreground = new SolidColorBrush(Colors.Red);
                warning.Content = "Vyplň všechny údaje";
            }
            else
            {
                warning.Content = "Odesláno";
                warning.Foreground = new SolidColorBrush(Colors.Green);

                var engine = new FileHelperEngine<Orders>();

                var orders = new List<Orders>();

                orders.Add(new Orders()
                {
                    Name = NameTextBox.Text,
                    Score = NumberTextBox.Text
                });

                engine.AppendToFile(Directory.GetCurrentDirectory() + "\\data.txt", orders);

                var records = engine.ReadFile(Directory.GetCurrentDirectory() + "\\data.txt");

                foreach (var record in records)
                {
                    scr.Add(new score(record.Name, record.Score));
                }

                /*StringBuilder csvcontent = new StringBuilder();
                csvcontent.Append(NameTextBox.Text + "|");
                csvcontent.Append(NumberTextBox.Text);
                csvcontent.AppendLine("");
                string csvpath = Directory.GetCurrentDirectory() + "\\data.txt";
                warning.Content = csvpath;
                File.AppendAllText(csvpath, csvcontent.ToString());*/
            }

        }
    }
}
