using Xam.Apis.View.Page;
using Xam.Apis.View.Page.MasterDetailPageApis;
using Xamarin.Forms;

namespace Xam.Apis
{
    //C:\Program Files (x86)\Java\jdk1.8.0_131\bin>keytool.exe -list -v -keystore "C:\Users\maly\AppData\Local\Xamarin\Mono for Android\debug.keystore" -alias androiddebugkey -storepass android -keypass android
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new MasterDetailPageApis();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
