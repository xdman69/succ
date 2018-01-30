using SQLiteExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTask : ContentPage
	{
		public AddTask ()
		{
			InitializeComponent ();
		}
        async void GoBackAsync(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        private static TodoItemDatabase _database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    IFileHelper filehelperInstance = DependencyService.Get<IFileHelper>();
                    _database = new TodoItemDatabase(filehelperInstance.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _database;
            }
        }
        async void HandleAdd(object sender, EventArgs ea)
        {
            if(taskName != null)
            {
                if(taskDesc != null)
                {

                    var dbConnection = Database;

                    TodoItemDatabase todoItemDatabase = Database;
                    TodoItem item = new TodoItem();
                    item.Name = taskName.Text;
                    item.Text = taskDesc.Text;
                    await Database.SaveItemAsync(item);

                    taskName.Text = "";
                    taskDesc.Text = "";

                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
        }
    }

}