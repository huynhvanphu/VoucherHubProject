using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("StoreOwnerNontification")]
    public class StoreOwnerNontification
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        public Guid Sender { set; get; }

        public AccountType SenderType { set; get; }

        [StringLength(255)]
        public string Content { set; get; }

        public Guid? StoreOwnerId { set; get; }
        [ForeignKey("FK_StoreOwnerNontification")]
        public StoreOwner StoreOwner { set; get; }
    }
}
