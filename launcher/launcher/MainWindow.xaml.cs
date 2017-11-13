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
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace launcher
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int SelectedIndex { get; set; }
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
                    copyList.Items.Add("Copy project");
                    exeList_Copy.Items.Add(folder);
                    if (File.Exists(add + @"\" + folder + @"\bin\Debug\info.csv"))
                    {
                        csvList.Items.Add("info.csv found            |  Edit");
                    }
                    else
                    {
                        csvList.Items.Add("info.csv not found     |  Create");
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
                MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to edit or delete info.csv?\nYes = Delete\nNo = Edit",
                "Edit project",
                MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.No)
                {
                    Process.Start(path + @"\info.csv".ToString());
                }
                if (result == MessageBoxResult.Yes)
                {
                    File.Delete(path + @"\info.csv");
                }
            }
            else
            {
                DateTime today = DateTime.Today;
                DateTime creation = Directory.GetCreationTime(exeList.Items[index].ToString());
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine(exeList_Copy.Items[index].ToString() + " Project");
                csvcontent.AppendLine("Creation time of the project: " + creation);
                csvcontent.AppendLine("This file has been created on: " + today);
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
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to delete " + exeList_Copy.Items[index].ToString() + "?",
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

        private void copyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    int index = copyList.SelectedIndex;
                    string path = exeList.Items[index].ToString();
                    path = System.IO.Path.GetDirectoryName(path);
                    string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\"));

                     void Copy(string sourceDirectory, string targetDirectory)
                    {
                        DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                        DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

                        CopyAll(diSource, diTarget);
                    }

                     void CopyAll(DirectoryInfo source, DirectoryInfo target)
                    {
                        Directory.CreateDirectory(target.FullName);

                        foreach (FileInfo fi in source.GetFiles())
                        {
                            fi.CopyTo(System.IO.Path.Combine(target.FullName, fi.Name), true);
                        }

                        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                        {
                            DirectoryInfo nextTargetSubDir =
                                target.CreateSubdirectory(diSourceSubDir.Name);
                            CopyAll(diSourceSubDir, nextTargetSubDir);
                        }
                    }

                     void Main()
                    {
                        string sourceDirectory = newPath;
                        string targetDirectory = fbd.SelectedPath;

                        Copy(sourceDirectory, targetDirectory);
                    }

                    Main();
                }
            }
        }

        private void exeList_Copy_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

            var item = VisualTreeHelper.HitTest(exeList_Copy, Mouse.GetPosition(exeList_Copy)).VisualHit;

            // find ListViewItem (or null)
            while (item != null && !(item is ListBoxItem))
                item = VisualTreeHelper.GetParent(item);

            if (item != null)
            {
                int i = exeList_Copy.Items.IndexOf(((ListBoxItem)item).DataContext);
                //System.Windows.MessageBox.Show(exeList.Items[i].ToString());
                exeList_Copy.Tag = exeList.Items[i].ToString();
                exeList_Copy.ToolTip = ((exeList_Copy.Tag)).ToString();
            }
        }
    }
}
