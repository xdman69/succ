using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void sample_click(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new Page1());
        }
        void xd()
        {
            
        }
    }
}
