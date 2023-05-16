using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("Voucher")]
    public class Voucher
    {
        [Key]
        [Required]
        public Guid Id { set; get; }

        [Required]
        public Guid Code { set; get; }

        public double Discount { set; get; }

        public DateTime CreatedAt { set; get; }

        //FK
        public Guid? CampaignId { set; get; }
        [ForeignKey("FK_Voucher_Campaign")]
        public Campaign Campaign { set; get; }

        public Guid? Customer_CampaignId { set; get; }
        [ForeignKey("FK_Voucher_Customer_Campaign")]
        public Customer_Campaign Customer_Campaign { set; get; }
    }
}
