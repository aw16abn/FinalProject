using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace FinalProject.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Init();
         
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_CreateAnAccount.TextColor = Constants.MainTextColor;
            Lbl_Login.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            App.StartCheckIfInternet(lbl_NoInternet, this);
        }

        private void Btn_Login_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        private void Btn_CreateAnAccount_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new CreateAccount();

        }

        private void Btn_FB_Login_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new FacebookLogin();
        }
    }
}
