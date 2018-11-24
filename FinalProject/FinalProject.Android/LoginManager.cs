using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using FinalProject.Models;
using static Android.Renderscripts.ProgramVertexFixedFunction;
using Xamarin.Auth;

namespace FinalProject.Droid
{
    public class LoginManager : ILoginManager
    {



        public MobileServiceUser GetCachedUser(IMobileServiceClient client)
        {
            var ctx = Xamarin.Forms.Forms.Context;
            var store = AccountStore.Create(ctx);

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

        public async Task LoginUserAsync(MobileServiceClient client)
        {
            var ctx = Xamarin.Forms.Forms.Context;

            var user = await client.LoginAsync(ctx,
                                               MobileServiceAuthenticationProvider.Twitter,
                                               Constants.LOGIN_RETURN_URI_SCHEME);

            CacheUserCredentials(client.MobileAppUri.OriginalString, user);
        }
    }
}