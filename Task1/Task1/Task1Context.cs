using Microsoft.EntityFrameworkCore;
using Task1.Constants;
using Task1.Data;

namespace Task1
{
    public class Task1Context : DbContext
    {
        public DbSet<RowModel> Rows { get; set; }

        public Task1Context() { }

        public Task1Context(DbContextOptions<Task1Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DbConstants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RowModel>()
                .HasKey(x => x.Id);
        }
    }
}
