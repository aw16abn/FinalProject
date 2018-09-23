using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views.DetailViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Create : ContentPage
	{
		public Create ()
		{
			InitializeComponent ();
            Init();
		}

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;

        }

        async void SelectedAddPhoto(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPhoto());
        }
        async void SelectedAddText(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddText());
        }
        async void SelectedAddRecording(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecording());
        }
        async void SelectedAddVideo(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddVideo());
        }
    }
}