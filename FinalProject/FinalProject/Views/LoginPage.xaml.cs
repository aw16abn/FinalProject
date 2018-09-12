using FinalProject.Models;
using FinalProject.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Init();
            
		}

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            App.StartCheckIfInternet(lbl_NoInternet, this);

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += async (s, e) => await SignInProcedureAsync(s, e);
        }

        async Task SignInProcedureAsync(object sender, EventArgs e)
        {
            Models.User user = new Models.User(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {
                await DisplayAlert("Login", "Login Successfull", "Ok");
                // var result = await App.RestService.Login(user); ---removed because we are not currently connecting to an actual server. 
                var result = new Token(); //Dummy token used because we are not actually connecting to a server at this point.

               
                
                if (result != null)
                {
                    //App.UserDatabase.SaveUser(user); //removed because we are not currently connecting to a server.
                    //App.TokenDatabase.SaveToken(result); //removed because we are not currently connecting to a server.
                    // await Navigation.PushAsync(new Dashboard());
                    if (Device.RuntimePlatform == Device.RuntimePlatform)
                    {
                        Application.Current.MainPage = new NavigationPage(new Dashboard());
                    }
                  //  else if (Device.RuntimePlatform == Device.iOS)
                  //  {
                  //      await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
                  //  }
                }
            }
            else
            {
                await DisplayAlert("Login", "Login not correct, empty username or password ", "Ok");
            }
        }

     
    }
}