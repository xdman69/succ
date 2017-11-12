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
using FileHelpers;
using System.Reflection;

namespace launcher
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void launcher()
        {
            string[] array = Directory.GetFiles(@"C:\users\Honza\Source", "*.sln", SearchOption.AllDirectories);
            foreach (string name in array)
            {
                string add = System.IO.Path.GetDirectoryName(name).ToString();
                string folder = System.IO.Path.GetFileNameWithoutExtension(name);
                string[] array1 = Directory.GetFiles(add + @"\" + folder + @"\bin\Debug", "*.exe", SearchOption.AllDirectories);
                foreach (string exe in array1)
                {
                    exeList.Items.Add(exe);
                    delList.Items.Add("Delete project");
                    exeList_Copy.Items.Add(folder);
                    if (File.Exists(add + @"\" + folder + @"\bin\Debug\info.csv"))
                    {
                        csvList.Items.Add("info.csv found");
                    }
                    else
                    {
                        csvList.Items.Add("info.csv not found");
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
            int index = exeList_Copy.SelectedIndex;
            Process.Start(exeList.Items[index].ToString());
        }
        private void csvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = csvList.SelectedIndex;
            string path = exeList.Items[index].ToString();
            path = System.IO.Path.GetDirectoryName(path);
            string file = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\"));
            file = Directory.GetFiles(path, "info.csv", SearchOption.AllDirectories).ToString();

            if (File.Exists(path + @"\info.csv"))
            {
                Process.Start(path + @"\info.csv".ToString());
            }
            else
            {
                DateTime today = DateTime.Today;
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("Created in: " + Assembly.GetEntryAssembly().GetName().Name + " Project");
                csvcontent.AppendLine("Date of creation of the .csv file: " + today);
                string csvpath = path + "\\info.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
                Process.Start(path + @"\info.csv".ToString());

            }

        }

        private void delList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = delList.SelectedIndex;
            string path = exeList.Items[index].ToString();
            path = System.IO.Path.GetDirectoryName(path);
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\"));
            //file = Directory.GetFiles(path, "info.csv", SearchOption.AllDirectories).ToString();

            if (Directory.Exists(newPath))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete " + exeList_Copy.Items[index].ToString() + "?",
                "Delete project",
                MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.No)
                            {
                                
                            }
                            if (result == MessageBoxResult.Yes)
                            {
                                Directory.Delete(newPath, true);
                            }
            }
            else
            {

            }
        }
    }
}
