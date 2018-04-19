using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UctenkovkaXamarin
{
	public partial class MainPage : ContentPage
	{
        private CreateNew createNew = new CreateNew();

        public List<Bill> tempdata;
        public MainPage()
		{
			InitializeComponent();
            data();
            listView.ItemsSource = tempdata;
        }

        async void newClick(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(createNew);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                listView.ItemsSource = tempdata;
            }

            else
            {
                listView.ItemsSource = tempdata.Where(x => x.Name.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        void data()
        {
            // all the temp data  
            tempdata = new List<Bill> {
            new Bill(){ Name = "Květináč", Date = "18/1/2018"},
            new Bill(){ Name = "Květináč", Date = "18/1/2018"},
            new Bill(){ Name = "Květináč", Date = "18/1/2018"},
            new Bill(){ Name = "Květináč", Date = "18/1/2018"},
            new Bill(){ Name = "Květináč", Date = "18/1/2018"},
            new Bill(){ Name = "Květináč", Date = "18/1/2018"},
            new Bill(){ Name = "Židle", Date = "18/1/2018"},
            new Bill(){ Name = "Židle", Date = "18/1/2018"},
            new Bill(){ Name = "Židle", Date = "18/1/2018"},
            new Bill(){ Name = "Židle", Date = "18/1/2018"},
            };
        }
    }
}
