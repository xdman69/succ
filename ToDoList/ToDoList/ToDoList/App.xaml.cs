﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLiteExample;
using ToDoList;
using Xamarin.Forms;

namespace SQLiteExample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
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

        public NavigationPage AddTask { get; set; }
    }
}
