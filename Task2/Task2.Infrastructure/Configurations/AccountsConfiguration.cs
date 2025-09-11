using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task2.Domen.Models;

namespace Task2.Infrastructure.Configurations
{
    /// <summary>
    /// Class thats configure account model in database
    /// </summary>
    public class AccountsConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountId);

            builder.Property(a => a.AccountCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.ClassCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.ClassName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(a => a.ReportLines)
                .WithOne(r => r.Account)
                .HasForeignKey(r => r.AccountId);
        }
    }
}
