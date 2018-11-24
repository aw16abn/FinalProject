using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public interface ILoginManager
    {

        Task LoginUser(MobileServiceClient client);

        MobileServiceUser GetCachedUser(IMobileServiceClient client);
    }
}
