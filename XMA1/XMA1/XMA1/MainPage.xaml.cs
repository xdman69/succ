using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace XMA1
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> Items = new ObservableCollection<string>();
        public MainPage()
        {
            InitializeComponent();
        }
  

        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string text = entryValue.Text;
            string nospace = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", "").ToLower().Replace(",","").Replace("?", "").Replace(".","").Replace("!","");
            char[] rev = nospace.ToCharArray();
            Array.Reverse(rev);
            string revs = new string(rev);

            if (nospace.Equals(revs))
            {
                Items.Add(text);
                nameList.ItemsSource = Items;
                check.Text = text + " je Palindrom";
                check.TextColor = Color.DarkGreen;
            } else
            {
                check.Text = text + " není Palindrom";
                check.TextColor = Color.DarkRed;
            }
        }
    }
}
