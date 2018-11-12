using FinalProject.Models;
using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MemoryItems : ContentPage
	{
		public MemoryItems ()
		{
			InitializeComponent ();
		}

        public MemoryItems(User user) : this()
        {
            this.BindingContext = new MemoryItemViewModel(user, Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((MemoryItemViewModel)this.BindingContext).Load();
        }
    }
}