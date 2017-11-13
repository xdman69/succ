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
    public partial class MainWindow : Window
    {
        public int SelectedIndex { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////LAUNCHER-START//////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void launcher()
        {
            string[] array = Directory.GetFiles(@"C:\users\Honza\source", "*.sln", SearchOption.AllDirectories);
            foreach (string name in array)
            {
                string add = System.IO.Path.GetDirectoryName(name).ToString();
                string folder = System.IO.Path.GetFileNameWithoutExtension(name);
                string[] array1 = Directory.GetFiles(add + @"\" + folder + @"\bin\Debug", "*.exe", SearchOption.AllDirectories);
                foreach (string exe in array1)
                {
                    listExe.Items.Add(exe);
                    deletel.Items.Add("Odstranit");
                    copyList.Items.Add("Zkopírovat");
                    ExeCopyL.Items.Add(folder);
                    if (File.Exists(add + @"\" + folder + @"\bin\Debug\info.csv"))
                    {
                        listCsv.Items.Add("info.csv byl nalezen          |  Edit");
                    }
                    else
                    {
                        listCsv.Items.Add("info.csv nebyl nalezen     |  Create");
                    }
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////LAUNCHER-END////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public MainWindow()
        {
            InitializeComponent();
            launcher();
        }


        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////CSV-EDIT-START///////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////


        private void listExe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ExeCopyL.SelectedIndex;
            Process.Start(listExe.Items[index].ToString());
        }
        private void listCsv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listCsv.SelectedIndex;
            string path = listExe.Items[index].ToString();
            path = System.IO.Path.GetDirectoryName(path);
            string file = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\"));
            file = Directory.GetFiles(path, "info.csv", SearchOption.AllDirectories).ToString();

            if (File.Exists(path + @"\info.csv"))
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Chcete soubor info.csv smazat? - Ano\nChcete soubor info.csv Upravit/zobrazit - Ne",
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
                DateTime dnes = DateTime.Today;
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("--------------------------------------------");
                csvcontent.AppendLine("Vytvoreno v: " + Assembly.GetEntryAssembly().GetName().Name );
                csvcontent.AppendLine("Datum vytvoreni: " + dnes);
                csvcontent.AppendLine("--------------------------------------------");
                string csvpath = path + "\\info.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
                Process.Start(path + @"\info.csv".ToString());
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////CSV-EDIT-END/////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        //-------------------------------------------------------------------------------------//

        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////DELETE-START/////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////


        private void deletel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = deletel.SelectedIndex;
            string path = listExe.Items[index].ToString();
            path = System.IO.Path.GetDirectoryName(path);
            string newPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\..\"));

            if (Directory.Exists(newPath))
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Opravdu chcete smazat tento soubor " + ExeCopyL.Items[index].ToString() + "?",
                "Odstranit",
                MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.No)
                {

                }
                if (result == MessageBoxResult.Cancel)
                {

                }

                if(result == MessageBoxResult.Yes)
                {
                    Directory.Delete(newPath, true);
                }
            }

            else
            {
               
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////DELETE-END///////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        //-------------------------------------------------------------------------------------//

        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////COPY-START///////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        private void copyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    int index = copyList.SelectedIndex;
                    string cesta = listExe.Items[index].ToString();
                    cesta = System.IO.Path.GetDirectoryName(cesta);
                    string nova_cesta = System.IO.Path.GetFullPath(System.IO.Path.Combine(cesta, @"..\..\..\"));

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

                        foreach (DirectoryInfo Directory in source.GetDirectories())
                        {
                            DirectoryInfo nextTargetSubDir =
                                target.CreateSubdirectory(Directory.Name);
                            CopyAll(Directory, nextTargetSubDir);
                        }
                    }

                    void cus()
                    {
                        string sourceDirectory = nova_cesta;
                        string targetDirectory = fbd.SelectedPath;

                        Copy(sourceDirectory, targetDirectory);
                    }

                    cus();
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////COPY-END/////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
    }
}
