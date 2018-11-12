using FinalProject.Models;
using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinalProject
{
    class AmendMemoryViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private MemoryItem targetItem;

        public AmendMemoryViewModel(MemoryItem item, INavigation navigation) : base(navigation)
        {
            targetItem = item;
           
            //AddMemoryCommand = new Command<>(, );
        }




        public MemoryItem Item
        {
            get { return targetItem; }
            set
            {
                targetItem = value;
             //   NotifyPropertyChanged("");
            }
        }

        public ICommand AmendMemoryCommand { get; private set; }

     
       
    }
}
