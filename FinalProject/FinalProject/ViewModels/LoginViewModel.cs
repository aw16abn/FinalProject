using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using FinalProject.Models;
using FinalProject.Views;
using System.ComponentModel;

namespace FinalProject.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public LoginViewModel(INavigation nav):base(nav)
        {
            LoginCommand = new Command(LoginAsync);
            MessagingCenter.Subscribe<UserService, LoginResult>(this, Constants.MSG_LOGIN_COMPLETE, LoginComplete);
        }

        private string _loginMsg = "Attempting to login with cached credentials";

        public string LoginMessage
        {
            get  { return _loginMsg; }
                set {
                    if (value != _loginMsg)
                    {
                        base.NotifyPropertyChanged("LoginMessage");
                    }
                    _loginMsg = value;
                }
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }

        public async void LoginAsync()
        {
            await App.GetUserService().Login();
        }

        public async Task TryLoginWithCachedCredentials()
        {
            await App.GetUserService().TryLoginWithCachedCredentialsAsync();
        }
        public void LoginComplete(UserService svc, LoginResult result)
        {
            //was the login successful
            if (!result.Succeeded)
            {
                //they couldn't log in, so we'll show the message
                LoginMessage = result.ErrorMessage;
            }
            else
            {
                //unsubscribe from messages
                MessagingCenter.Unsubscribe<UserService>(this, Constants.MSG_LOGIN_COMPLETE);
            }

        }


    }
}
