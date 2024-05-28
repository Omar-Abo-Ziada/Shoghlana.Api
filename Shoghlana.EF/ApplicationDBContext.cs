using Microsoft.EntityFrameworkCore;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProjectImages> ProjectImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(j => j.Id);
                entity.Property(j => j.MinBudget).HasColumnType("Money");
                entity.Property(j => j.MaxBudget).HasColumnType("Money");
                entity.Property(j => j.Status).HasDefaultValue(JobStatus.Active);

                entity.HasData(
                    new Job
                    {
                        Id = 1,
                        Title = "Software Developer",
                        PostTime = DateTime.Now,
                        Description = "Develop software applications",
                        MinBudget = 1000,
                        MaxBudget = 2000,
                        ExperienceLevel = ExperienceLevel.Intermediate,
                        Status = JobStatus.Active,
                        ClientId = 1 
                    },
                    new Job
                    {
                        Id = 2,
                        Title = "BackEnd Developer",
                        PostTime = DateTime.Now,
                        Description = "Develop software applications",
                        MinBudget = 1000,
                        MaxBudget = 2000,
                        ExperienceLevel = ExperienceLevel.Intermediate,
                        Status = JobStatus.Active,
                        ClientId = 1
                    }

                );

                // Map relation with skills (M:M)
                entity.HasMany(j => j.skills)
                      .WithMany(s => s.jobs)
                      .UsingEntity<Dictionary<string, object>>("jobSkills",
                          j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                          j => j.HasOne<Job>().WithMany().HasForeignKey("JobId"));
            });

            // Other entity configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
