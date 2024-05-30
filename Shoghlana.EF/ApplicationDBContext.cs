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

        //   public DbSet<FreelancerSkills> FreelancerSkills { get; set; }

        //   public DbSet<JobSkills> JobSkills { get; set; }

        //        public DbSet<ProjectSkills> ProjectSkills { get; set; }

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


            modelBuilder.Entity<Freelancer>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Name).HasMaxLength(50);

                // map relation with skills >> M:M
                entity.HasMany(f => f.skills)
                      .WithMany(s => s.freelancers)
                      .UsingEntity<Dictionary<string, object>>("freelancerSkills",  // j 
                    j => j.HasOne<Skill>()
                          .WithMany()
                          .HasForeignKey("SkillId"),
                    j => j.HasOne<Freelancer>()
                          .WithMany()
                          .HasForeignKey("FreelancerId"));
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

            #region Initial Data

            modelBuilder.Entity<Freelancer>().HasData
            (
                new Freelancer() { Id = 1, Name = "أحمد محمد", Title = "مطور الواجهة الخلفية" },
                new Freelancer() { Id = 2, Name = "علي سليمان", Title = "مطور الواجهة الأمامية" },
                new Freelancer() { Id = 3, Name = "وائل عبد الرحيم", Title = "مطور الواجهة الخلفية" }
            );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
