using Microsoft.EntityFrameworkCore;
using PayGateDotNetServer.Common.Models;
using System.Security.Claims;

namespace PayGateDotNetServer.DAL
{
    public class PayGateDotNetServerDBContext : DbContext
    {
        public PayGateDotNetServerDBContext(DbContextOptions options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>().HasKey(vf => new { vf.CustomerId, vf.AccountId });
            modelBuilder.Entity<Transaction>().HasOne(tv => tv.Customer).WithMany().HasForeignKey(tv => tv.CustomerId);
            modelBuilder.Entity<Transaction>().HasOne(v => v.Account).WithMany().HasForeignKey(v => v.AccountId);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}