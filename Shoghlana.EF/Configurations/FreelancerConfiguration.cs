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
    internal class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
    {
        public void Configure(EntityTypeBuilder<Freelancer> builder)
        {

            builder.HasData
            (
                new Freelancer() { Id = 1, Name = "أحمد محمد", Title = "مطور الواجهة الخلفية" },
                new Freelancer() { Id = 2, Name = "علي سليمان", Title = "مطور الواجهة الأمامية" },
                new Freelancer() { Id = 3, Name = "وائل عبد الرحيم", Title = "مطور الواجهة الخلفية" }
            );

            //modelBuilder.Entity<Freelancer>(entity =>
            //{
            //    entity.HasKey(f => f.Id);

            //    entity.Property(f => f.Name).HasMaxLength(50);


            //    entity.HasMany(f => f.Notifications)
            //          .WithOne(n => n.Freelancer)
            //          .HasForeignKey(n => n.FreelancerId);

            //    entity.HasMany(f => f.Skills)
            //          .WithMany(s => s.)
            //          .UsingEntity<Dictionary<string, object>>("freelancerSkills",
            //        j => j.HasOne<Skill>()
            //              .WithMany()
            //              .HasForeignKey("SkillId"),
            //        j => j.HasOne<Freelancer>()
            //              .WithMany()
            //              .HasForeignKey("FreelancerId"));

            //    //map relation with skills >> M:M
            //    entity.HasMany(f => f.Skills)
            //          .WithMany(s => s.freelancers)
            //          .UsingEntity<Dictionary<string, object>>("freelancerSkills",  // j 
            //        j => j.HasOne<Skill>()
            //              .WithMany()
            //              .HasForeignKey("SkillId"),
            //        j => j.HasOne<Freelancer>()
            //              .WithMany()
            //              .HasForeignKey("FreelancerId"));
            //});        }
        }
    }
}
