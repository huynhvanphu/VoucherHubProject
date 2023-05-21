using System;
using ClientAPI.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ClientAPI.Services
{
    public class SystemService
    {
        
        public SystemService()
        {

        }
        public void AddAccountToSession(ISession session, Account account)
        {
            var sessionAccount = new Account
            {
                Id = account.Id,
                Username = account.Username,
                Password = Guid.NewGuid().ToString(),
                Role = account.Role
            };
            var jsonString = JsonConvert.SerializeObject(sessionAccount);
            session.Clear();
            session.SetString("account", "username");

            
        }
    }
}
