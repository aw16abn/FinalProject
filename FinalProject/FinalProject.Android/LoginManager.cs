using System;
using System.Linq;
using System.Threading.Tasks;
using Android.Views;
using Microsoft.WindowsAzure.MobileServices;
using FinalProject.Models;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(FinalProject.Droid.LoginManager))]

namespace FinalProject.Droid
{
    public class LoginManager : ILoginManager
    {



        public MobileServiceUser GetCachedUser(IMobileServiceClient client)
        {
            var ctx = Android.App.Application.Context;
            var store = AccountStore.Create(ctx,"password");

            var account = store.FindAccountsForService(client.MobileAppUri.OriginalString).FirstOrDefault();
            if (account != null)
            {
                var user = new MobileServiceUser(account.Username);
                user.MobileServiceAuthenticationToken = account.Properties["token"];
                return user;
            }
            else
            {
                return null;
            }

        }

        public async Task LoginUser(MobileServiceClient client)
        {
            var ctx = Android.App.Application.Context;

            var user = await client.LoginAsync(ctx,
                                               MobileServiceAuthenticationProvider.Facebook,
                                               Constants.LOGIN_RETURN_URI_SCHEME);

            CacheUserCredentials(client.MobileAppUri.OriginalString, user);
        }

        private void CacheUserCredentials(string mobileAppUrl, MobileServiceUser user)
        {
            var ctx = Android.App.Application.Context;
            var store = AccountStore.Create(ctx, "password");

            var account = new Account(user.UserId);
            account.Properties.Add("token", user.MobileServiceAuthenticationToken);
            store.Save(account, mobileAppUrl);
        }
    }
}