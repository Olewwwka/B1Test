using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Domen.Models;

namespace Task2.Infrastructure.Configurations
{
    /// <summary>
    /// Class thats configure report in database
    /// </summary>
    public class ReportsConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(r => r.ReportId);

            builder.Property(r => r.BankName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Currency)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(r => r.ReportLines)
                .WithOne(rl => rl.Report)
                .HasForeignKey(rl => rl.ReportId);
        }
    }
}
