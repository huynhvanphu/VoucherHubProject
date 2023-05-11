using System;
namespace ClientAPI.Models
{
    public class Campaign
    {
        public int id { set; get; }

        public DateTime createdAt { set; get; }

        public string name { set; get; }

        public DateTime startDate { set; get; }

        public DateTime endDate { set; get; }

        public string description { set; get; }

    }
}
