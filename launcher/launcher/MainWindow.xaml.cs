using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace launcher
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void launcher()
        {
            string[] array = Directory.GetFiles(@"C:\users\valesja15\Source", "*.sln", SearchOption.AllDirectories);
            foreach (string name in array)
            {
                string add = System.IO.Path.GetDirectoryName(name).ToString();
                string folder = System.IO.Path.GetFileNameWithoutExtension(name);
                string[] array1 = Directory.GetFiles(add + @"\" + folder + @"\bin\Debug", "*.exe", SearchOption.AllDirectories);
                foreach(string exe in array1)
                {
                    exeList.Items.Add(exe);
                    var file = Directory.GetFiles(add + @"\" + folder + @"\bin\Debug", "info.csv", SearchOption.AllDirectories);
                    if (file == null)
                    {
                        csvList.Items.Add("info.csv file nenalezen");
                    }
                    else
                    {
                        csvList.Items.Add("info.csv file nalezen");
                    }
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            launcher();
        }

        private void exeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Process.Start(exeList.SelectedItem.ToString());
        }
        private void csvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = csvList.SelectedIndex;
            string path = exeList.Items[index].ToString();
            path = System.IO.Path.GetDirectoryName(path);
            string file = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\"));
            file = Directory.GetFiles(path, "info.csv", SearchOption.AllDirectories).ToString();

            if (file == null)
            {
                csvList.Items.Add("xddd");
            }
            else
            {
                StringBuilder csvfile = new StringBuilder();
                string csvpath = path;

            }

        }

    }
}
