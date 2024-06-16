using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF
{
    internal class FreelancerNotificationsConfiguration : IEntityTypeConfiguration<FreelancerNotification>
    {
        public void Configure(EntityTypeBuilder<FreelancerNotification> builder)
        {
            builder.HasKey(fn => fn.Id);

            builder.HasOne(fn => fn.Freelancer)
                      .WithMany(f => f.Notifications)
                      .HasForeignKey(fn => fn.FreelancerId);
        }
    }
}
