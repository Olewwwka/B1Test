using Microsoft.EntityFrameworkCore;
using Task1.Constants;
using Task1.Data;

namespace Task1
{
    /// <summary>
    /// EF Core context to Task1 app
    /// </summary>
    public class Task1Context : DbContext
    {
        /// <summary>
        /// Collection of rows from database
        /// </summary>
        public DbSet<RowModel> Rows { get; set; }
        /// <summary>
        /// Constructor to migrations 
        /// </summary>
        public Task1Context() { }
        /// <summary>
        /// Constructor to create instance with connection to database
        /// </summary>
        /// <param name="options">Options with connection string</param>
        public Task1Context(DbContextOptions<Task1Context> options) : base(options) { }
        /// <summary>
        /// Configure database to use PostgreSQL
        /// </summary>
        /// <param name="optionsBuilder">Builder used to configur options</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(DbConstants.ConnectionString);
            }
        }
        /// <summary>
        /// Configure entities of context
        /// </summary>
        /// <param name="optionsBuilder">Builder used to configur options</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RowModel>()
                .HasKey(x => x.Id);
        }
    }
}
