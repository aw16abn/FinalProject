using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinalProject.Views
{
    class MemoryItemViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private Memory memory;
        private ObservableCollection<Memory> items;

        public MemoryItemViewModel(Memory selectedMemory, INavigation navigation) : base(navigation)
        {
            memory = selectedMemory;
            AddMemory = new Command<Memory>(PlaceBidOnItem);
            MessagingCenter.Subscribe<PlaceBidViewModel, AuctionItem>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }

        public ICommand AddMemory
        {
            get;
            private set;
        }

       // public void PlaceBidOnItem(AuctionItem item)
     //   {
      //      Navigation.PushAsync(
      //          new PlaceBid(item));
      //  }

        public void ItemUpdated(PlaceBidViewModel model, AuctionItem item)
        {
            if (Items != null)
            {
                var targetItem = Items.First((i) => i.Id == item.Id);
                targetItem.CurrentBid = item.CurrentBid;
            }
        }
        public ObservableCollection<AuctionItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                NotifyPropertyChanged("Items");
            }
        }

        public void Load()
        {
            //escape if already loaded
            if (Items != null)
                return;

            IsLoading = true;

            App.GetAuctionService().GetItems(auction.Id).ContinueWith(
                (ait) =>
                {
                    if (ait.Exception == null)
                    {
                        Items = new ObservableCollection<AuctionItem>(ait.Result);
                    }
                    else
                    {
                        //handle exception
                    }

                    IsLoading = false;
                });
        }



    }
}
