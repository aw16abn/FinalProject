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
    public partial class AddMemory : ContentPage
    {

        public AddMemory()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
        }

        private async void Btn_AddMemory_Clicked(object sender, EventArgs e)
        {
            MemoryItem memory = new MemoryItem
            {
                title = this.Entry_Title.Text,
                Description = this.Entry_Description.Text,
                date = this.DatePicker.Date,
            };

            await App.GetMemoryService().AddMemory(memory);

            

        }
    }

}
