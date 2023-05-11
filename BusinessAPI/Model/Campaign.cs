using System;
namespace BusinessAPI.Model
{
    public class Campaign
    {
        public int id { set; get; }

        public string name { set; get; }

        public string description { set; get; }

        public DateTime startDate { set; get; }

        public DateTime endDate { set; get; }

        public DateTime createdAt { set; get; }
    }
}
