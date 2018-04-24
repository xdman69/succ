using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.OS;
using Plugin.Geolocator;

namespace UctenkovkaXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateNew : ContentPage
	{
		public CreateNew ()
		{
			InitializeComponent ();
            Locationer();
        }

        async Task Locationer()
        {
            TimeSpan ts = TimeSpan.FromSeconds(10);
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(ts);
            var adress = await locator.GetAddressesForPositionAsync(position);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
            foreach (var a in adress)
            {
                Adress.Text += a + "\n";
                
            }
        }

        async void backClick(object sender, EventArgs args)
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        void newClick(object sender, EventArgs args)
        {
            //await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}