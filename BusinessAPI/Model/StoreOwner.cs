using System;
namespace BusinessAPI.Model
{
    public class StoreOwner
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Website { set; get; }

        public string ImagePath { set; get; }

        public Account Account { set; get; }
    }
}
