﻿using System;
using System.Collections.Generic;
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

        [StringLength(255)]
        public string Email { set; get; }

        public DateTime CreatedAt { set; get; }

        //FK
        public Guid? AccountId { set; get; }
        [ForeignKey("FK_Customer_Account")]
        public Account Account { set; get; }

        //Reverse
        public virtual ICollection<Customer_Campaign> Customer_Campaigns { set; get; }

        public virtual ICollection<CustomerNontification> CustomerNontifications { set; get; }

    }
}
