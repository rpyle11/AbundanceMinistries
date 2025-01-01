using System.Configuration;
using System.Diagnostics;
using System.IO;
using AbLedger.Entities;
using Microsoft.EntityFrameworkCore;


namespace AbLedger.Data
{
    public class AbLedgerDataContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AppErrors> AppErrors { get; set; }

        public DbSet<Payees> Payees { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DbCnn"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>().ToTable("Accounts");
            modelBuilder.Entity<AppErrors>().ToTable("AppErrors");
            modelBuilder.Entity<Payees>().ToTable("Payees");
            modelBuilder.Entity<Transactions>().ToTable("Transactions");
        }
    }
}
