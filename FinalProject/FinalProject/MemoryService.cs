using FinalProject.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class MemoryService
    {
        private static MobileServiceClient azClient;


        public MemoryService (string serviceBaseUri)
        {
            azClient = new MobileServiceClient(serviceBaseUri);
        }

        public async Task<IEnumerable<User>>GetUser()
        {
            var table = azClient.GetTable<User>();
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<MemoryItem>> GetItems(int Memory_Id)
        {
            var table = azClient.GetTable<MemoryItem>();
            var query = table.Where(ai=>ai.Memory_ID == Memory_Id);
            return await table.ReadAsync(query);
        }

        public async Task<User> AddUser(User newUser)
        {
            var table = azClient.GetTable<User>();
            await table.InsertAsync(newUser);
            return newUser;
        }

        public async Task<IEnumerable<MyMemoryItem>> GetMyItems()
        {
            return await azClient.InvokeApiAsync<IEnumerable<MyMemoryItem>>("MyItems", HttpMethod.Get, null);
            
        }

    }
}
