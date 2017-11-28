using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent();
            xd();
        }

        async void sample_click(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        void xd()
        {
            List<imagelist> conList = new List<imagelist>()
            {
                new imagelist("http://www.freeiconspng.com/uploads/person-outline-icon-png-person-outline-icon-png-person-17.png", "Karel"),
                new imagelist("http://www.freeiconspng.com/uploads/person-outline-icon-png-person-outline-icon-png-person-17.png", "Big Shaq"),
                new imagelist("http://www.freeiconspng.com/uploads/person-outline-icon-png-person-outline-icon-png-person-17.png", "Amandy")
            };

            listView.ItemsSource = conList;
        }
    }
}