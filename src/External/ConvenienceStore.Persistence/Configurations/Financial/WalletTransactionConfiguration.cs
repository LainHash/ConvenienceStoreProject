using ConvenienceStore.Domain.Entities.Financial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Financial
{
    internal class WalletTransactionConfiguration
        : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.ToTable("WalletTransactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.BalanceBefore)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.BalanceAfter)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.ReferenceId)
                .HasMaxLength(100);

            builder.Property(x => x.ReferenceType);

            builder.HasOne(x => x.Wallet)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
