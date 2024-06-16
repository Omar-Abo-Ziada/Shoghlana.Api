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
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Freelancer)
                     .WithMany(f => f.Portfolio)
                     .HasForeignKey(p => p.FreelancerId);

            builder.HasData(
              new Project { Id = 1, Title = "Project1", Description = "Description for Project1", FreelancerId = 1, Poster = new byte[] { 0x20, 0x21, 0x22, 0x23 } },
              new Project { Id = 2, Title = "Project2", Description = "Description for Project2", FreelancerId = 2, Poster = new byte[] { 0x20, 0x21, 0x22, 0x23 } }
          );

            //entity.HasMany(p => p.skills)
            //      .WithMany(s => s.projects)
            //      .UsingEntity<Dictionary<string, object>>("projectSkills",
            //    j => j.HasOne<Skill>()
            //          .WithMany()
            //          .HasForeignKey("SkillId"),
            //    j => j.HasOne<Project>()
            //          .WithMany()
            //          .HasForeignKey("ProjectId"));

            // map relation with skills >> M:M
            //entity.HasMany(p => p.skills)
            //      .WithMany(s => s.projects)
            //      .UsingEntity<Dictionary<string, object>>("projectSkills",
            //    j => j.HasOne<Skill>()
            //          .WithMany()
            //          .HasForeignKey("SkillId"),
            //    j => j.HasOne<Project>()
            //          .WithMany()
            //          .HasForeignKey("ProjectId"));
        }
    }
}
