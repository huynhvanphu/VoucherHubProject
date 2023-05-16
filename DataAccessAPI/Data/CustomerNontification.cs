using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("CustomerNontification")]
    public class CustomerNontification
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        public Guid Sender { set; get; }

        public AccountType SenderType { set; get; }

        [StringLength(255)]
        public string Content { set; get; }

        public Guid? CustomerId { set; get; }
        [ForeignKey("FK_CustomerNontification")]
        public Customer Customer { set; get; }

    }
}
