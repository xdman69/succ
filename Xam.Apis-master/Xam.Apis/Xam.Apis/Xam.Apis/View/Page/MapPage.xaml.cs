using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xam.Apis.View.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();

            CustomMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(50.1248708, 14.5023646), Distance.FromKilometers(0.1)));

            var position = new Position(50.1248708, 14.5023646); // Latitude, Longitude
		    var pin = new Pin
		    {
		        Type = PinType.Place,
		        Position = position,
		        Label = "SPS na Proseku",
		        Address = "Best school in Prague"

		    };

		    CustomMap.Pins.Add(pin);
        }
    }
}