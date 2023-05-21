using System;
namespace ClientAPI.Models
{
    public enum AccountRole
    {
        Admin =  1, StoreOwner = 2, Customer = 3
    }
    public class Account
    {
        public string Id { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }

        public AccountRole Role { set; get; }
    }
}
