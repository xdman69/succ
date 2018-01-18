using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SQLiteExample
{
    public partial class MainPage : ContentPage
    {
        public ToDoList.AddTask detailPage = new ToDoList.AddTask();
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var dbConnection = App.Database;

            TodoItemDatabase todoItemDatabase = App.Database;
            TodoItem item = new TodoItem();
            item.Name = "VYNES KOŠ";
            item.Text = "Musíš vynést koš brácho";
            App.Database.SaveItemAsync(item);


            var itemsFromDb = App.Database.GetItemsAsync().Result;

            Debug.WriteLine(itemsFromDb.Count);
            foreach (TodoItem todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }


            ToDoList.ItemsSource = itemsFromDb;
        }

        void sample_click(object sender, EventArgs args)
        {
            var dbConnection = App.Database;
            dbConnection.DeleteItems();
        }

        async void addAsync(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(detailPage);
        }
    }
}