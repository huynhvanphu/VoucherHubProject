using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        [StringLength(255)]
        public string Name { set; get; }

        public DateTime DateOfBirth { set; get; }

        [StringLength(255)]
        public string Address { set; get; }

        [StringLength(12)]
        public string Phone { set; get; }
    }
}
