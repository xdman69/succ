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
            /*TodoItem item = new TodoItem();
            item.Name = "VYNES KOŠ";
            item.Text = "Musíš vynést koš brácho";
            App.Database.SaveItemAsync(item);*/


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
            ToDoList.BeginRefresh();
            var itemsFromDb = App.Database.GetItemsAsync().Result;
            ToDoList.ItemsSource = itemsFromDb;
            ToDoList.EndRefresh();

        }

        async void addAsync(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(detailPage);
        }
        async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var action = await DisplayActionSheet("Úkol", "Zrušit", null, "Upravit", "Smazat");
            switch (action)
            {
                case "Upravit":
                    await Navigation.PushModalAsync(detailPage);


                    break;
                case "Smazat":
                    IFileHelper filehelperInstance = DependencyService.Get<IFileHelper>();
                    TodoItemDatabase delete = new TodoItemDatabase(filehelperInstance.GetLocalFilePath("TodoSQLite.db3"));

                    var item = (TodoItem)e.SelectedItem;

                    await delete.DeleteItemAsync(item);

                    ToDoList.BeginRefresh();
                    var itemsFromDb = App.Database.GetItemsAsync().Result;
                    ToDoList.ItemsSource = itemsFromDb;
                    ToDoList.EndRefresh();
                    break;                
            }
        }

        protected override void OnAppearing()
        {
            ToDoList.BeginRefresh();
            var itemsFromDb = App.Database.GetItemsAsync().Result;
            ToDoList.ItemsSource = itemsFromDb;
            ToDoList.EndRefresh();
        }
    }
}