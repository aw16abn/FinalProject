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

        public async Task<IEnumerable<Memory>>GetMemory()
        {
            var table = azClient.GetTable<Memory>();
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<Memory>> GetItems(string Id)
        {
            var table = azClient.GetTable<Memory>();
            var query = table.Where(ai=>ai.Id == Id);
            return await table.ReadAsync(query);
        }

        public async Task<Memory> AddMemory(Memory newMemory)
        {
            var table = azClient.GetTable<Memory>();
            await table.InsertAsync(newMemory);
            return newMemory;
        }

        public async Task<IEnumerable<Memory>> GetMyItems()
        {
            return await azClient.InvokeApiAsync<IEnumerable<Memory>>("MyItems", HttpMethod.Get, null);
            
        }

    }
}
