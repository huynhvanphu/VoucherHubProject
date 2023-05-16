using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessAPI.Data
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public Guid Id { set; get; }

        [Required]
        [StringLength(20)]
        public string Username { set; get; }

        [Required]
        [StringLength(20)]
        public string Password { set; get; }
    }
}
