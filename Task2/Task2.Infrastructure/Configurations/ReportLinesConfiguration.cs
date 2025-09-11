using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Domen.Models;

namespace Task2.Infrastructure.Configurations
{
    /// <summary>
    /// Class thats configure model ReportLine in database
    /// </summary>
    public class ReportLinesConfiguration : IEntityTypeConfiguration<ReportLine>
    {
        public void Configure(EntityTypeBuilder<ReportLine> builder)
        {
            builder.HasKey(r => r.Id);
        }
    }
}
