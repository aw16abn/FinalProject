using FinalProject.Models;
using FinalProject.ViewModels;
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
	public partial class FacebookLogin : ContentPage
	{
		public FacebookLogin ()
		{
			InitializeComponent ();

            var model = new LoginViewModel(this.Navigation);
            this.BindingContext = model;
        }


        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
           
          

           

           
        }
    }
}