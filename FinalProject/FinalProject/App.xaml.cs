using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Views;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Collections.Generic;
using Timer = System.Threading.Timer;
using Microsoft.WindowsAzure.MobileServices;
using FinalProject.Views.Menu;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FinalProject
{
	public partial class App : Application
	{
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

         static MemoryService _MemoryService;
        static UserService _UserService;

        static App()
        {
            _MemoryService = new MemoryService("https://mercury2.azurewebsites.net");
            _UserService = new UserService("https://mercury2.azurewebsites.net");
        }

        

        public App ()
		{
			InitializeComponent();

			MainPage = new MainPage();

          //  MessagingCenter.Subscribe<UserService, LoginResult>(this, Constants.MSG_LOGIN_COMPLETE);

        }

        public static MemoryService GetMemoryService()
        {
            return _MemoryService;
        }

        public static UserService GetUserService()
        {
            return _UserService;
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

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return UserDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

        public void LoginComplete (UserService svc, LoginResult result)
        {
            //was the login successful 
            if (result.Succeeded)
            {
                Device.BeginInvokeOnMainThread(() =>
                    //login succeeded so we'll go to the main page now 
                    Application.Current.MainPage = new MasterDetail());

                MessagingCenter.Unsubscribe<UserService>(this, Constants.MSG_LOGIN_COMPLETE);
            }
        }

       


        //-------------Internet Connection-------------------------------

        public static void StartCheckIfInternet (Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentPage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                } ,null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        public static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread((Action)(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await App.showDisplayAlertAsync();
                        }
                    }
                }));


            }

            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = true;
                    labelScreen.IsVisible = false;
                });
           }
        }

        public static bool checkIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }

        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await showDisplayAlert();
                }
                return false;
            }
            return false;
        }

        private static async Task showDisplayAlert()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Device has no internet, please reconnect. ", "ok");
            noInterShow = false;
        }

        private static async Task showDisplayAlertAsync()
        {
            noInterShow = false;
            await currentPage.DisplayAlert("Internet","Device has no internet, please reconnect. ","ok");
            noInterShow = false;
        }

        public static MobileServiceClient MobileService =
    new MobileServiceClient(
    "https://finalp.azurewebsites.net");
        private static MemoryService _memoryService;
    }
}
