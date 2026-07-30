using ConvenienceStore.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConvenienceStore.Persistence.Configurations.Identity
{
    internal class EmailChangeRequestConfiguration
        : IEntityTypeConfiguration<EmailChangeRequest>
    {
        public void Configure(EntityTypeBuilder<EmailChangeRequest> builder)
        {
            builder.ToTable("EmailChangeRequests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(x => x.PublicId)
                .IsRequired();

            builder.Property(x => x.NewEmail)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CurrentEmailConfirmed)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.EmailChangeRequests)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
