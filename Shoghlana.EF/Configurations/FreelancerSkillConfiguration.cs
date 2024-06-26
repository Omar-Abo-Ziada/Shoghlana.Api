using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoghlana.Core.Models;

namespace Shoghlana.EF.Configurations
{
    internal class FreelancerSkillConfiguration : IEntityTypeConfiguration<FreelancerSkills>
    {
        public void Configure(EntityTypeBuilder<FreelancerSkills> builder)
        {
            builder.HasKey(fs => new { fs.SkillId, fs.FreelancerId });

            builder.HasOne(fs => fs.Freelancer)
                      .WithMany(f => f.Skills)
                      .HasForeignKey(fs => fs.FreelancerId);

            builder.HasOne(fs => fs.Skill)
                       .WithMany(s => s.freelancers)
                       .HasForeignKey(fs => fs.SkillId);
        }
    }
}