using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("Customer_Campaign")]
    public class Customer_Campaign
    {
        [Key]
        public Guid Id { set; get; }

        public DateTime GrantedDate { set; get; }

        //FK
        public Guid? CampaignId { set; get; }
        [ForeignKey("FK_Customer_Campaign_Campaign")]
        public Campaign Campaign { set; get; }

        public Guid? CustomerId { set; get; }
        [ForeignKey("FK_Customer_Campaign_Customer")]
        public Customer Customer { set; get; }

        //Reverse
        public virtual ICollection<Voucher> Vouchers { set; get; }

    }
}
