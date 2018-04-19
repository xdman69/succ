using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Apis.View.Page.MasterDetailPageApis
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailPageApis : MasterDetailPage
	{
		public MasterDetailPageApis()
		{
			InitializeComponent ();
            masterPage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}