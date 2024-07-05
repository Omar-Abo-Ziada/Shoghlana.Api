using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Configurations
{
    internal class ClientNotificationsConfiguration : IEntityTypeConfiguration<ClientNotification>
    {
        public void Configure(EntityTypeBuilder<ClientNotification> builder)
        {

            builder.HasKey(cn => cn.Id);

            builder.Property(cn => cn.Title).IsRequired().HasMaxLength(50);
            builder.Property(cn => cn.description).IsRequired(false).HasMaxLength(2000);

            builder.HasOne(cn => cn.Client)
                      .WithMany(c => c.Notifications)
                      .HasForeignKey(cn => cn.ClientId);
        }
    }
}
