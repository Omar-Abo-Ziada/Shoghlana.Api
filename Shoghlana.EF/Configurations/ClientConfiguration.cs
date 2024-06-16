using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50);

            builder.HasMany(c => c.Notifications)
                      .WithOne(n => n.Client)
                      .HasForeignKey(n => n.ClientId);


            builder.HasData
                (
                  new Client { Id = 1, Name = "Client1" },
                  new Client { Id = 2, Name = "Client2" }
               );

        }
    }
}