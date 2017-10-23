using System;
using System.Collections.Generic;
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

namespace WpfAppMaterial
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        int progress = 0;
        int result = 0;
        string questions { get; set; }
        int rand { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        public void answ1_Click(object sender, RoutedEventArgs e)
        {

            if (result.Equals(answ1.Content))
            {
                proBar.Value = progress = progress + 10;
            }
            else
            {
                proBar.Value = progress = progress - 10;
            }
            try
            {
                if ((string)answ1.Content == "Konec")
                {
                    Environment.Exit(0);
                }
            } catch(Exception)
            {

            }

            int rand = random.Next(0, 10);

            int num1 = random.Next(0, 100);
            int num2 = random.Next(0, 100);
            result = num1 + num2;
            questions = string.Format("Kolik se rovná {0} + {1}?", num1, num2);

            question.Text = questions;
            if (rand % 2 == 0)
            {
                answ1.Content = num1 + num2;
                answ2.Content = num2 * 2;
            } else
            {
                answ1.Content = num1 *2;
                answ2.Content = num1 + num2;
            }

            if (proBar.Value >= 100)
            {
                progress = 100;
                question.Text = "Vyhrál jsi!";
                answ1.Content = "Konec";
                answ2.Content = "Konec";
            }
            else if (proBar.Value <= 0)
            {
                progress = 0;
            }
        }

        private void answ2_Click(object sender, RoutedEventArgs e)
        {

            if (result.Equals(answ2.Content))
            {
                proBar.Value = progress = progress + 10;
            }
            else
            {
                proBar.Value = progress = progress - 10;
            }
            try
            {
                if ((string)answ2.Content == "Znovu")
                {
                    Environment.Exit(0);
                }
            } catch(Exception)
            {

            }

            int rand = random.Next(0, 10);

            int num1 = random.Next(0, 100);
            int num2 = random.Next(0, 100);
            result = num1 + num2;

            questions = string.Format("Kolik se rovná {0} + {1}?", num1, num2);

            question.Text = questions;

            if (rand % 2 != 0)
            {
                answ2.Content = num1 + num2;
                answ1.Content = num1 * 2;
            }
            else
            {
                answ2.Content = num1 * 2;
                answ1.Content = num1 + num2;

            }

            if (proBar.Value >= 100)
            {
                progress = 100;
                question.Text = "Vyhrál jsi!";
                answ1.Content = "Konec";
                answ2.Content = "Konec";
            }
            else if (proBar.Value <= 0)
            {
                progress = 0;
            }

        }
    }

    
}
