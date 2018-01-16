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

namespace browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void browser_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private void site_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                browser.Source = new Uri("http://" + site.Text);
                site.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void site_TextChanged(object sender, TextChangedEventArgs e)
        {
            site.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
