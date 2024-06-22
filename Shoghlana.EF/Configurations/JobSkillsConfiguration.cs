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
    internal class JobSkillsConfiguration : IEntityTypeConfiguration<JobSkills>
    {
        public void Configure(EntityTypeBuilder<JobSkills> builder)
        {
            builder.HasKey(js => new { js.JobId, js.SkillId });

            builder.HasOne(js => js.Job)
                .WithMany(j => j.skills)
                .HasForeignKey(js => js.JobId);

            builder.HasOne(js => js.Skill)
                .WithMany()
                .HasForeignKey(js => js.SkillId);
        }
    }
}