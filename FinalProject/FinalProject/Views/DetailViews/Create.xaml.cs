using FinalProject.Models;
using FinalProject.Views.DetailViews;
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

        async void SelectedAddPhoto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPhoto());
        }
        async void SelectedAddText(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMemory());
        }
        //async void SelectedAddRecording(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new AddRecording());
        //}
        //async void SelectedAddVideo(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new AddVideo());
        //}
    }
}