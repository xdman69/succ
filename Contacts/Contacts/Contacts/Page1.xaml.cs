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
        public MainPage detailPage = new MainPage();
        public string Text;
        public Page1 ()
		{
			InitializeComponent();
            xd();
        }

        public void xd()
        {
            List<imagelist> conList = new List<imagelist>()
            {
                new imagelist(ImageSource.FromFile("contact.png"), Text = "Karel","+1-800-469-24", "karelxd@gmail.com","https://media.novinky.cz/058/460584-top_foto1-tk8xd.jpg?1415694607", 1),
                new imagelist(ImageSource.FromFile("contact.png"), Text = "Big SHAQ","+1-800-420-69","bigshaq@outlook.com","https://i.ytimg.com/vi/j1tvVg2DJaw/maxresdefault.jpg" ,2),
                new imagelist(ImageSource.FromFile("contact.png"), Text = "Amandy","+1-800-325-23","amandyxd@yahoo.com","http://sm.askmen.com/askmen_in/article/t/tips-for-d/tips-for-dating-a-latina_dxwk.jpg" ,3)
            };

            listView.ItemsSource = conList;
        }
        public async void contact_click(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            } else
            {
                detailPage.BindingContext = listView.SelectedItem;
                string content = listView.SelectedItem.ToString();
                await Navigation.PushModalAsync(detailPage);
            }
        }
    }
}