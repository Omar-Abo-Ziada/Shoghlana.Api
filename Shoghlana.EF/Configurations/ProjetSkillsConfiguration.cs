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
    internal class ProjetSkillsConfiguration : IEntityTypeConfiguration<ProjectSkills>
    {
        public void Configure(EntityTypeBuilder<ProjectSkills> builder)
        {

            builder.HasKey(e => new { e.SkillId, e.ProjectId });

            builder.HasOne(ps => ps.Project)
                      .WithMany(p => p.Skills)
                      .HasForeignKey(ps => ps.ProjectId);

            builder.HasOne(ps => ps.Skill)
                       .WithMany(s => s.projects)
                       .HasForeignKey(ps => ps.SkillId);

        }
    }
}
