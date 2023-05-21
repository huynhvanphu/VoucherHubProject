using System;
namespace BusinessAPI.Model
{
    public class Account
    {
        public Guid Id { set; get; }

        public string Username { set; get; }

        public string Password { set; get; }
    }
}
