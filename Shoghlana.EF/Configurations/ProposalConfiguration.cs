using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF.Configurations
{
    internal class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Price)
                      .HasColumnType("Money");

                builder.Property(p => p.Status)
                      .HasDefaultValue(ProposalStatus.Waiting);

                builder.HasOne(p => p.Freelancer)
                      .WithMany(f => f.Proposals)
                      .HasForeignKey(p => p.FreelancerId);

                builder.HasOne(p => p.Job)
                      .WithMany(j => j.Proposals)
                      .HasForeignKey(p => p.JobId);


            builder.HasData(
                new Proposal { Id = 1, Price = 300, Status = ProposalStatus.Waiting, FreelancerId = 1, JobId = 1 },
                new Proposal { Id = 2, Price = 400, Status = ProposalStatus.Waiting, FreelancerId = 2, JobId = 2 }
            );

        }
    }
}
