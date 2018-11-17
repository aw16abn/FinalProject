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
    class AddMemoryViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private MemoryItem targetItem;

        public AddMemoryViewModel(MemoryItem item, INavigation navigation) : base(navigation)
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
             NotifyPropertyChanged("Item");
            }
        }

        public ICommand AmendMemoryCommand { get; private set; }


        public async void ExecuteAddMemory(MemoryItem parameter)
        {

         //   var newMemoryItem = await App.GetMemoryService().AddUser(
              //  new MemoryItem { Memory_ID = targetItem.Id, BidAmount = BidAmount });

           // Item.CurrentBid = newBid.BidAmount;

            MessagingCenter.Send<AddMemoryViewModel, MemoryItem>(this, Constants.MSG_ITEMUPDATED, Item);

            //move back to the page they were on before bidding
            await Navigation.PopAsync();

        }

    }
}
