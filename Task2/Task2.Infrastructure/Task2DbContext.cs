using Microsoft.EntityFrameworkCore;
using Task2.Domen.Models;
using Task2.Infrastructure.Configurations;

namespace Task2.Infrastructure
{
    public class Task2DbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ReportLine> ReportLines { get; set; }

        public Task2DbContext(DbContextOptions<Task2DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportsConfiguration());
            modelBuilder.ApplyConfiguration(new ReportLinesConfiguration());
            modelBuilder.ApplyConfiguration(new AccountsConfiguration());
        }
    }
}
