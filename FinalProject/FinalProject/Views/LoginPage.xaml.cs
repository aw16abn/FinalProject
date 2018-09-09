﻿using FinalProject.Models;
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

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += async (s, e) => await SignInProcedureAsync(s, e);
        }

        async Task SignInProcedureAsync(object sender, EventArgs e)
        {
            Models.User user = new Models.User(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {
                await DisplayAlert("Login", "Login Successfull", "Ok");
                var result = await App.RestService.Login(user);
                if (result.Access_Token != null)
                {
                    App.UserDatabase.SaveUser(user);
                }
            }
            else
            {
                await DisplayAlert("Login", "Login not correct, empty username or password ", "Ok");
            }
        }
	}
}