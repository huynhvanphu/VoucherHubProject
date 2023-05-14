using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccessAPI.Data
{
    public class VoucherHubDbContext : DbContext
    {
        public VoucherHubDbContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Customer> Customers { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
