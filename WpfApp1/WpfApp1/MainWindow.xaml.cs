using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        private Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            peopleList.ItemsSource = persons;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            persons.Add(new Person("name " + r.Next()));
            Debug.WriteLine("xdd");
        }

        private static int i = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            i++;

            counter.Content = i.ToString();
        }
    }
}
