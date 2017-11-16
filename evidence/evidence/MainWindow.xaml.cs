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
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace evidence
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool xmlConv = false;
        public MainWindow()
        {
            InitializeComponent();
            xd();
        }
        public void xd() {

            List<Cars> seznamAut = new List<Cars>()
            {
                new Cars("Audi", "A7", 2017, 500),
                new Cars("Audi", "RS6", 2015, 12500),
                new Cars("Audi", "Q7", 2013, 50000)
            };

            foreach (var auto in seznamAut)
            {
                //string json = JsonConvert.SerializeObject(auto);
                carList.Items.Add(auto);
            }
        }

        private void Button_Click_xml(object sender, RoutedEventArgs e)
        {
            for (int i = carList_xml.Items.Count - 1; i >= 0; --i)
            {
                carList_xml.Items.RemoveAt(i);
            }

            foreach (var item in carList.Items)
            {
                string it = item.ToString();
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(it.GetType());
                serializer.Serialize(stringwriter, it);
                carList_xml.Items.Add(stringwriter.ToString());
            }
            xmlConv = true;
            saveButton.Content = "SAVE TO .XML FILE";
        }

        private void Button_Click_json(object sender, RoutedEventArgs e)
        {
            for (int i = carList_xml.Items.Count - 1; i >= 0; --i)
            {
                carList_xml.Items.RemoveAt(i);
            }

            foreach (var item in carList.Items)
            {
                string json = JsonConvert.SerializeObject(item);
                carList_xml.Items.Add(json);
            }
            xmlConv = false;
            saveButton.Content = "SAVE TO .JSON FILE";
        }

        private void save_Click_xml(object sender, RoutedEventArgs e)
        {
            string dirpath = Directory.GetCurrentDirectory();
            if (xmlConv == false)
            {
                foreach (var json in carList_xml.Items)
                {
                    System.IO.File.AppendAllText(dirpath + @"\text.json", json.ToString() + "\n");
                }
            } else
            {
                foreach (var xml in carList_xml.Items)
                {
                    System.IO.File.AppendAllText(dirpath + @"\text.xml", xml.ToString() + "\n");
                }
            }
        }

        private void Button_Click_csv(object sender, RoutedEventArgs e)
        {
            foreach (var csv in carList.Items)
            {
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.Append(csv);
                csvcontent.AppendLine("");
                string csvpath = Directory.GetCurrentDirectory() + @"\data.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
            }
        }
    }
}
