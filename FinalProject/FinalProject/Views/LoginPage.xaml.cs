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
		}

        void SignInProcedure(object sender, EventArgs e)
        {
            Models.User user = new Models.User(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {
                DisplayAlert("Login","Login Successfull","Ok");
            }
            else
            {
                DisplayAlert("Login", "Login not correct, empty username or password ", "Ok");
            }
        }
	}
}