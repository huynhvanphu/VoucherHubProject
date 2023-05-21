using System;
using DataAccessAPI.Data;

namespace ClientAPI.Models.ClientModels
{
    public class StoreOwnerAccount
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Website { set; get; }

        public string ImagePath { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }

        public string Email { set; get; }
    }
}
