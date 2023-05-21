using System;
using System.Net.Http;
using ClientAPI.Models;
using Microsoft.Extensions.Configuration;

namespace ClientAPI.Services
{
    public class StoreOwnerService
    {
        private readonly IConfiguration _configuration;

        private readonly string ConnectionString;

        public StoreOwnerService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("BusinessApi");
        }
        public HttpResponseMessage AddStoreOwnerApi(StoreOwnerAccount storeOwner)
        {
            if (storeOwner != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConnectionString);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<StoreOwnerAccount>("StoreOwner/SignUp", storeOwner);

                    postTask.Wait();

                    return postTask.Result;
                }
            }
            else return null;
        }
        public string GetStoreOwnerAccountIdByUsername(string username)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(ConnectionString);
                //HTTP GET
                var responseTask = client.GetAsync($"StoreOwner/GetAccountIdByUsername?username={username}");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();

                    readTask.Wait();

                    var accountId = readTask.Result;

                    return accountId;
                }

                return string.Empty;
                
            }
        }

        public bool IsStoreOwnerUsernameExisted(string username)
        {
            var accountId = false;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(ConnectionString);
                //HTTP GET
                var responseTask = client.GetAsync($"StoreOwner/IsUsernameExisted?username={username}");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();

                    readTask.Wait();

                    accountId = readTask.Result;
                }
            }
            return accountId;
        }

        public StoreOwner AccountLogin(string username, string password)
        {
            var storeOwner = new StoreOwner();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConnectionString);
                //HTTP GET
                var responseTask = client.GetAsync($"StoreOwner/AccountLogin?Username={username}&Password={password}");

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StoreOwner>();

                    readTask.Wait();

                    storeOwner = readTask.Result;
                }
            }
            return storeOwner;
        }
    }
}
