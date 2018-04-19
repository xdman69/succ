using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.OS;

namespace UctenkovkaXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateNew : ContentPage
	{
		public CreateNew ()
		{
			InitializeComponent ();
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