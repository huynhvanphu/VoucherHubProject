using System;
namespace ClientAPI.Models
{
    public class StoreOwner
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Website { set; get; }

        public string ImagePath {set; get;}

        public string Email { set; get; }

        public DateTime CreatedAt { set; get; }

        public Guid AccountId { set; get; }

        public Account account { set; get; }

    }
}
