using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("Campaign")]
    public class Campaign
    {
        [Key]
        public Guid Id { set; get; }

        public string Name { set; get; }

        public DateTime StartDate { set; get; }

        public DateTime EndDate { set; get; }

        public string Slogan { set; get; }

        public DateTime CreatedAt { set; get; }

        //FK
        public Guid? CampaignGameId { set; get; }
        [ForeignKey("FK_Campaign_CampaignGame")]
        public CampaignGame CampaignGame { set; get; }

        //Reverse
        public virtual ICollection<Voucher> Vouchers { set; get; }
    }
}
