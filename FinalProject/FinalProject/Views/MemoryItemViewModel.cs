using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using FinalProject.Models;
using Xamarin.Forms;

namespace FinalProject.Views
{
     class MemoryItemViewModel: ViewModelBase, INotifyPropertyChanged
    {
        private User user;
        private ObservableCollection<MemoryItem> items;

        public MemoryItemViewModel(User selectedUser, INavigation navigation) : base(navigation)
        {
            user = selectedUser;
          //  PlaceBid = new Command<MemoryItem>(PlaceBidOnItem);
          //  MessagingCenter.Subscribe<PlaceBidViewModel, AuctionItem>(this, Constants.MSG_ITEMUPDATED, ItemUpdated);
        }

        public ICommand PlaceBid
        {
            get;
            private set;
        }

        public void PlaceBidOnItem(MemoryItem item)
        {
           // Navigation.PushAsync(
               // new PlaceBid(item));
        }

        //public void ItemUpdated(PlaceBidViewModel model, AuctionItem item)
        //{
        //    if (Items != null)
        //    {
        //        var targetItem = Items.First((i) => i.Id == item.Id);
        //        targetItem.CurrentBid = item.CurrentBid;
        //    }
        //}
        public ObservableCollection<MemoryItem> Items
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

            App.GetMemoryService().GetItems(user.User_ID).ContinueWith(
                (ait) =>
                {
                    if (ait.Exception == null)
                    {
                        Items = new ObservableCollection<MemoryItem>(ait.Result);
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
