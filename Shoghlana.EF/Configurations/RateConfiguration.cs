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
    internal class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {

            builder.HasKey(r => r.Id);

            builder.HasCheckConstraint("CK_VALUE_RANGE", "[Value] BETWEEN 1 AND 5");

            builder.HasOne(r => r.Job)
                 .WithOne(j => j.Rate)
                 .HasForeignKey<Rate>(r => r.JobId);


            builder.HasData(
                new Rate { Id = 1, Value = 4, JobId = 1 },
                new Rate { Id = 2, Value = 5, JobId = 2 }
            );

        }
    }
}
