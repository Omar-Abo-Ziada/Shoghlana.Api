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
    internal class JobConfiguraion : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

                builder.Property(j => j.MinBudget)
                      .HasColumnType("Money");

                builder.Property(e => e.MaxBudget)
                      .HasColumnType("Money");

                builder.HasOne(j => j.Client)
                      .WithMany(c => c.Jobs)
                      .HasForeignKey(j => j.ClientId);

                builder.Property(j => j.Status)
                      .HasDefaultValue(JobStatus.Active);

                builder.HasOne(j => j.Freelancer)
                      .WithMany(f => f.WorkingHistory)
                      .HasForeignKey(j => j.FreelancerId);

                builder.HasOne(j => j.Category)
                     .WithMany(c => c.Jobs)
                     .HasForeignKey(j => j.CategoryId);


            builder.HasData(
                new Job
                {
                    Id = 1,
                    Title = "Job1",
                    PostTime = DateTime.Now,
                    Description = "Description for Job1",
                    MinBudget = 100,
                    MaxBudget = 500,
                    ExperienceLevel = ExperienceLevel.Beginner,
                    Status = JobStatus.Active,
                    ClientId = 1,
                    FreelancerId = 1,
                    CategoryId = 1
                },
                new Job
                {
                    Id = 2,
                    Title = "Job2",
                    PostTime = DateTime.Now,
                    Description = "Description for Job2",
                    MinBudget = 200,
                    MaxBudget = 700,
                    ExperienceLevel = ExperienceLevel.Intermediate,
                    Status = JobStatus.Active,
                    ClientId = 2,
                    FreelancerId = 2,
                    CategoryId = 2
                }

            );


            //builder.HasMany(j => j.skills)
            //      .WithMany(s => s.Job)
            //      .Usingbuilder<Dictionary<string, object>>("jobSkills",
            //    j => j.HasOne<Skill>()
            //          .WithMany()
            //          .HasForeignKey("SkillId"),
            //    j => j.HasOne<Job>()
            //          .WithMany()
            //          .HasForeignKey("JobId"));

            ////map relation with skills >> M:M
            //    builder.HasMany(j => j.skills)
            //          .WithMany(s => s.jobs)
            //          .Usingbuilder<Dictionary<string, object>>("jobSkills",
            //        j => j.HasOne<Skill>()
            //              .WithMany()
            //              .HasForeignKey("SkillId"),
            //        j => j.HasOne<Job>()
            //              .WithMany()
            //              .HasForeignKey("JobId"));

        }
    }
}
