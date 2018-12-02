using FinalProject.Models;
using FinalProject.ViewModels;
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
            var model = new LoginViewModel(this.Navigation);
            this.BindingContext = model;
            
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

        public async Task SignInProcedureAsync(object sender, EventArgs e)
        {
            Models.Users user = new Models.Users(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {

                ActivitySpinner.IsVisible = true;
                // var result = await App.RestService.Login(user); ---removed because we are not currently connecting to an actual server.

                var result = await App.GetUserService().LoginUser(user);

                //  var result = new Token(); //Dummy token used because we are not actually connecting to a server at this point.
                await DisplayAlert("Login", "Login Successfull", "Ok");





                if (result != null)
                {
                    ActivitySpinner.IsVisible = false;
                    //App.UserDatabase.SaveUser(user); //removed because we are not currently connecting to a server.
                    //App.TokenDatabase.SaveToken(result); //removed because we are not currently connecting to a server.
                    // await Navigation.PushAsync(new Dashboard());
                    if (Device.RuntimePlatform == Device.RuntimePlatform)
                    {
                        Application.Current.MainPage = new MasterDetail();
                    }
              
                }
            }
            else
            {
                await DisplayAlert("Login", "Login not correct, empty username or password ", "Ok");
                ActivitySpinner.IsVisible = false;
            }
        }


    }
}