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

        DbSet<Account> Accounts { set; get; }

        DbSet<Campaign> Campaigns { set; get; }

        DbSet<Customer_Campaign> Customer_Campaigns { set; get; }

        DbSet<StoreOwner> StoreOwners { set; get; }

        DbSet<CampaignGame> CampaignGames { set; get; }

        DbSet <Voucher> Vouchers { set; get; }

        DbSet<CustomerNontification> CustomerNontifications { set; get; }

        DbSet<StoreOwnerNontification> StoreOwnerNontifications { set; get; }

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
