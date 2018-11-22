using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateAccount : ContentPage
	{
		public CreateAccount ()
		{
			InitializeComponent ();
            Init();
            
		}

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            //Lbl_Username.TextColor = Constants.MainTextColor;
           // Lbl_Password.TextColor = Constants.MainTextColor;
            
           

           

            
        }

        private async void Btn_CreateAccount_Clicked(object sender, EventArgs e)
        {

            Users newUser = new Users
            {
               FirstName= this.Entry_Name.Text,
                LastName = this.Entry_Last_Name.Text,
                Username = this.Entry_Username.Text,
                Email = this.Entry_Email.Text,
                Password = this.Entry_Password.Text
            };

            await App.GetUserService().AddUser(newUser);



            Application.Current.MainPage = new MainPage();

        }

     
    }
}