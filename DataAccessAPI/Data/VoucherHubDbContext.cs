using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccessAPI.Data
{
    public class VoucherHubDbContext : DbContext
    {
        public VoucherHubDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { set; get; }

        public DbSet<Account> Accounts { set; get; }

        public DbSet<Campaign> Campaigns { set; get; }

        public DbSet<Customer_Campaign> Customer_Campaigns { set; get; }

        public DbSet<StoreOwner> StoreOwners { set; get; }

        public DbSet<CampaignGame> CampaignGames { set; get; }

        public DbSet <Voucher> Vouchers { set; get; }

        public DbSet<CustomerNontification> CustomerNontifications { set; get; }

        public DbSet<StoreOwnerNontification> StoreOwnerNontifications { set; get; }

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
