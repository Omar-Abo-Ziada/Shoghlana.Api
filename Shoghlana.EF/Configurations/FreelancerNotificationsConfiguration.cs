using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;

namespace Shoghlana.EF
{
    internal class FreelancerNotificationsConfiguration : IEntityTypeConfiguration<FreelancerNotification>
    {
        public void Configure(EntityTypeBuilder<FreelancerNotification> builder)
        {
            builder.HasKey(fn => fn.Id);

            builder.Property(fn => fn.Title).IsRequired().HasMaxLength(50);
            builder.Property(fn => fn.description).IsRequired(false).HasMaxLength(2000);

            builder.HasOne(fn => fn.Freelancer)
                      .WithMany(f => f.Notifications)
                      .HasForeignKey(fn => fn.FreelancerId);
        }
    }
}