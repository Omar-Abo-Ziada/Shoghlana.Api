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
    internal class ProjectImagesConfiguration : IEntityTypeConfiguration<ProjectImages>
    {
        public void Configure(EntityTypeBuilder<ProjectImages> builder)
        {
            builder.HasKey(pI => pI.Id);

            builder.HasOne(pI => pI.Project)
                     .WithMany(p => p.Images)
                     .HasForeignKey(pI => pI.ProjectId);


            builder.HasData(
              new ProposalImages { Id = 1, Image = new byte[] { 0x20, 0x21, 0x22, 0x23 }, ProposalId = 1 },
              new ProposalImages { Id = 2, Image = new byte[] { 0x20, 0x21, 0x22, 0x23 }, ProposalId = 2 }
          );
        }
    }
}
