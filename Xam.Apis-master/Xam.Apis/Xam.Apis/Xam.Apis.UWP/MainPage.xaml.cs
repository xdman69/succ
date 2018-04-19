using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Xam.Apis.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            var rendererAssemblies = new[]
            {
                typeof(Xamarin.Forms.GoogleMaps.UWP.MapRenderer).GetTypeInfo().Assembly
            };
            Xamarin.FormsMaps.Init("ApsfKCgcxxragsJDdyYf4a6EYg4JQgFucbUhO50FboGSgR-w3grtCE57rgsrz1GB");
            Xamarin.FormsGoogleMaps.Init("ApsfKCgcxxragsJDdyYf4a6EYg4JQgFucbUhO50FboGSgR-w3grtCE57rgsrz1GB");
            LoadApplication(new Xam.Apis.App());
        }
    }
}
