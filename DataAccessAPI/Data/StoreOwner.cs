using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("StoreOwner")]
    public class StoreOwner
    {
        [Key]
        [Required]
        public Guid Id { set; get; }

        [StringLength(255)]
        [Required]
        public string Name { set; get; }

        [StringLength(255)]
        [Required]
        public string Address { set; get; }

        [StringLength(12)]
        public string Phone { set; get; }

        [StringLength(100)]
        public string Website { set; get; }

        [StringLength(255)]
        public string ImagePath { set; get; }

        public DateTime CreatedAt { set; get; }

        //FK
        public Guid? CampaignId { set; get; }
        [ForeignKey("FK_StoreOwner_Campaign")]
        public Campaign Campaign { set; get; }

        public Guid? AccountId { set; get; }
        [ForeignKey("FK_StoreOwner_Account")]
        public Account Account { set; get; }

        //Reverse
        public virtual ICollection<Campaign> Campaigns { set; get; }

        public virtual ICollection<StoreOwnerNontification> StoreOwnerNontifications { set; get; }
    }
}
