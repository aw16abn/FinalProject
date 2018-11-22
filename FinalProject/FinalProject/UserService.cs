using FinalProject.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        //public async Task<Users> LoginUser (Users Username, Users Password)
        //{
        //    var table = azClient.GetTable<Users>();

       
        //}

    }
}
