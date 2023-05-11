using System;
using System.Collections.Generic;
using ClientAPI.Models;

namespace ClientAPI.Services
{
    public class CustomerService : List<Customer>
    {
        public CustomerService() 
        {
            this.AddRange(new Customer[]
            {
                new Customer()
                {
                    Id = Guid.NewGuid(), Name = "Felix", Address = "Ben Tre"
                },
                new Customer()
                {
                    Id = Guid.NewGuid(), Name = "Hanna", Address = "Bao Loc"
                },
                new Customer()
                {
                    Id = Guid.NewGuid(), Name = "Kelvon", Address = "Tra Vinh"
                },
            });
        }
    }
}
