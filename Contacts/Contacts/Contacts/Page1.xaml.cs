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
                new imagelist(ImageSource.FromFile("contact.png"), "Karel", 1),
                new imagelist(ImageSource.FromFile("contact.png"), "BigShaq", 2),
                new imagelist(ImageSource.FromFile("contact.png"), "Amandy", 3)
            };

            listView.ItemsSource = conList;
        }
        async void contact_click(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            } else
            {
                await Navigation.PopModalAsync();
                await Navigation.PushModalAsync(new MainPage());
            }
            
        }
    }
}