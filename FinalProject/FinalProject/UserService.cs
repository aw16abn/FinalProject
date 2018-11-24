using FinalProject.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
   public  class UserService
    {
        private static MobileServiceClient azClient;

        public UserService (string serviceBaseUri)
        {
            azClient = new MobileServiceClient(serviceBaseUri);
        }

        public async Task<Users> AddUser(Users newUser)
        {
            var table = azClient.GetTable<Users>();
            await table.InsertAsync(newUser);
            return newUser;
        }

        public async Task<IEnumerable<Users>> LoginUser (Users user)
        {

            var table = azClient.GetTable<Users>();
            var query = table.Where(u => u.Username == user.Username && u.Password == user.Password);
            return await table.ReadAsync(query);

      
        }

        public async Task Login()
        {
            var result = new LoginResult();

            ILoginManager mgr = Xamarin.Forms.DependencyService.Get<ILoginManager>();

            if (mgr !=null)
            {
                try
                {
                    await mgr.LoginUser(azClient);
                    result.Succeeded = azClient.CurrentUser != null;
                }
                catch (Exception ex)
                {
                    result.Succeeded = false;
                    result.ErrorMessage = ex.Message;
                }

            }
            else
            {
                result.Succeeded = false;
                result.ErrorMessage = "Login manager is not implmented for this current platform.";
            }

            MessagingCenter.Send<UserService, LoginResult>(this, Constants.MSG_LOGIN_COMPLETE, result);
        }

        public async Task TryLoginWithCachedCredentialsAsync()
        {
            var result = new LoginResult();

            ILoginManager mgr = Xamarin.Forms.DependencyService.Get<ILoginManager>();

            if (mgr != null)
            {
                //try to get catch user credentials and test them
                try
                {
                    var user = mgr.GetCachedUser(azClient);
                    if (user != null) {
                        azClient.CurrentUser = user;
                        bool isCredentialValid = await TestLoginCredentialIsValidAsync();
                        if (isCredentialValid)
                        {
                            result.Succeeded = true;
                        }
                        else
                        {
                            result.Succeeded = false;
                            result.ErrorMessage = "Cached credentials expired, please login again.";
                        }
                    }

                }
                catch
                {
                    result.Succeeded = false;
                    result.ErrorMessage = "Failed to use cached credentials, please login.";
                }
            }
            MessagingCenter.Send<UserService, LoginResult>(this, Constants.MSG_LOGIN_COMPLETE, result);
        }

        private async Task<bool> TestLoginCredentialIsValidAsync()
        {
            try
            {
                var result = await azClient.InvokeApiAsync("LoginValidation", HttpMethod.Get, null);
                return true;
            }
            catch (Exception ex)
            {
                //test for unauthorized
                return false;
            }
        }

    }
}
