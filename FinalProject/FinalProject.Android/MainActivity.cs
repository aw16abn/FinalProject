using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Media;
using Microsoft.WindowsAzure.MobileServices;

namespace FinalProject.Droid
{
    [Activity(Label = "FinalProject", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle bundle)
        {
          TabLayoutResource = Resource.Layout.Tabbar;
           ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // This MobileServiceClient has been configured to communicate with the Azure Mobile App and
            // Azure Gateway using the application url. You're all set to start working with your Mobile App!
            Microsoft.WindowsAzure.MobileServices.MobileServiceClient Mercury2Client = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient(
            "https://mercury2.azurewebsites.net");

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

           await CrossMedia.Current.Initialize();

            //Initialize the azure mobile client
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       


    }
}

