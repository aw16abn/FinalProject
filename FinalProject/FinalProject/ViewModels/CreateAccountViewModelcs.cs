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
    class CreateAccountViewModel: ViewModelBase, INotifyPropertyChanged
    {

        private  Users targetItem;

        public CreateAccountViewModel(Users user, INavigation navigation): base(navigation)
        {
            targetItem = user;
           // AddUserCommand = new Command<User>(ExecuteAddUser);
        }

       // public async void ExecuteAddUser(User arg)
  //      {
            //try
            //{
               // var newUser = await App.GetUserService();
               //     new User {  })
           // }
    //    }


    //    public ICommand AddUserCommand { get; private set; }


    }
}
