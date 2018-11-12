using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinalProject.Views
{
    class UsersViewModel: ViewModelBase, INotifyPropertyChanged
    {
        public UsersViewModel(INavigation navigation) : base(navigation)
        {
            SelectUser = new Command<User>(GoToUser);
            amendMemory = new Command<MyMemoryItem>(ChangeMemory);
            RefreshMyItems = new Command(LoadMyItems);
            RefreshUsers = new Command(LoadUsers);

            //MessagingCenter.Subscribe<AmendMemoryViewModel, MemoryItem,>(this, Constants.UserUPDATED, ItemUpdated);
        }

        //command and delegate to move to auction items
        public ICommand SelectUser
        {
            get;
            private set;
        }

        public void GoToUser(User user)
        {
            Navigation.PushAsync(
                new MemoryItems(user));
        }

        // command and delegate to move to place bid
        public ICommand amendMemory
        {
            get; private set;

        }

        public void ChangeMemory(MyMemoryItem item)
        {
            var targetItem = new MemoryItem
            {
                Memory_ID = item.Memory_ID,
                title = item.title,
                Description = item.Description,
                
            };

          //  Navigation.PushAsync(new amendMemory(targetItem));
        }

        // command and delegate to load auctions
        public ICommand RefreshUsers
        {
            get; private set;
        }

        public async void LoadUsers(object parameter)
        {
            IsLoading = true;
            try
            {
                var userResults = await App.GetMemoryService().GetUser();
                Users = new ObservableCollection<User>(userResults);
            }
            catch (Exception ex)
            {
                //TODO: alert to error
            }
            finally
            {
                IsLoading = false;
            }
        }

        // command and delegate to load custom items
        public ICommand RefreshMyItems
        {
            get; private set;
        }

        public async void LoadMyItems(object parameter)
        {
            IsLoading = true;
            try
            {
                var itemsResult = await App.GetMemoryService().GetMyItems();
                MyMemoryItems = new ObservableCollection<MyMemoryItem>(itemsResult);
            }
            catch (Exception ex)
            {
                //TODO: alert to error
            }
            finally
            {
                IsLoading = false;
            }
        }

        // collections for auctions and items

        private ObservableCollection<MyMemoryItem> myItems;

        public ObservableCollection<MyMemoryItem> MyMemoryItems
        {
            get { return myItems; }
            set
            {
                myItems = value;
                NotifyPropertyChanged("MyMemoryItems");
            }
        }

        private ObservableCollection<User> userList;

        public ObservableCollection<User> Users
        {
            get { return userList; }
            set
            {
                userList = value;
                NotifyPropertyChanged("Users");
            }
        }

        //trigger to load all items
        public void Load()
        {
            //escape if already loaded
            if (Users != null)
                return;

            LoadUsers(null);
            LoadMyItems(null);

        }

        public void ItemUpdated(AmendMemoryViewModel model, MemoryItem item)
        {
            if (MyMemoryItems != null)
            {

            }
        }

    }
}

