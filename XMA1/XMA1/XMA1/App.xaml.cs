using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Xamarin.Forms;

namespace XMA1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new XMA1.MainPage();
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
    }
}
