using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shoghlana.Core.Enums;
using Shoghlana.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoghlana.EF
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>

    {
        public DbSet<Freelancer> Freelancers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<FreelancerSkills> FreelancerSkills { get; set; }
        public DbSet<JobSkills> JobSkills { get; set; }
        public DbSet<ProjectSkills> ProjectSkills { get; set; }

        public DbSet<FreelancerNotification> FreelancerNotifications { get; set; }

        public DbSet<ClientNotification> ClientNotifications { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<ProjectImages> ProjectImages { get; set; }

        public DbSet<ProposalImages> ProposalImages { get; set; }

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

            //modelBuilder.Entity<Client>(entity =>
            //{
            //    entity.HasKey(c => c.Id);
            //});

            // Freelancer-Notification relationship
            modelBuilder.Entity<FreelancerNotification>()
                .HasKey(fn => new { fn.FreelancerId, fn.NotificationId });

            modelBuilder.Entity<FreelancerNotification>()
                .HasOne(fn => fn.Freelancer)
                .WithMany(f => f.Notifications)
                .HasForeignKey(fn => fn.FreelancerId);

            modelBuilder.Entity<FreelancerNotification>()
                .HasOne(fn => fn.Notification)
                .WithMany(n => n.FreelancerNotifications)
                .HasForeignKey(fn => fn.NotificationId);

            // Client-Notification relationship
            modelBuilder.Entity<ClientNotification>()
                .HasKey(cn => new { cn.ClientId, cn.NotificationId });

            modelBuilder.Entity<ClientNotification>()
                .HasOne(cn => cn.Client)
                .WithMany(c => c.Notifications)
                .HasForeignKey(cn => cn.ClientId);

            modelBuilder.Entity<ClientNotification>()
                .HasOne(cn => cn.Notification)
                .WithMany(n => n.ClientNotifications)
                .HasForeignKey(cn => cn.NotificationId);

            modelBuilder.Entity<Freelancer>(entity =>
            {
                //entity.HasKey(f => f.Id);

                entity.Property(f => f.Name).HasMaxLength(50);

                // map relation with skills >> M:M
                //entity.HasMany(f => f.Skills)
                //      .WithMany(s => s.freelancers)
                //      .UsingEntity<Dictionary<string, object>>("freelancerSkills",  // j 
                //    j => j.HasOne<Skill>()
                //          .WithMany()
                //          .HasForeignKey("SkillId"),
                //    j => j.HasOne<Freelancer>()
                //          .WithMany()
                //          .HasForeignKey("FreelancerId"));
            });


            modelBuilder.Entity<FreelancerSkills>(entity =>
            {
                entity.HasKey(fs => new { fs.SkillId, fs.FreelancerId });

                entity.HasOne(fs => fs.Freelancer)
                      .WithMany(f => f.Skills)
                      .HasForeignKey(fs => fs.FreelancerId);

                entity.HasOne(fs => fs.Skill)
                       .WithMany(s => s.freelancers)
                       .HasForeignKey(fs => fs.SkillId);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(j => j.Id);

                entity.Property(j => j.MinBudget)
                      .HasColumnType("Money");

                entity.Property(e => e.MaxBudget)
                      .HasColumnType("Money");

                entity.HasOne(j => j.Client)
                      .WithMany(c => c.Jobs)
                      .HasForeignKey(j => j.ClientId);

                entity.Property(j => j.Status)
                      .HasDefaultValue(JobStatus.Active);

                entity.HasOne(j => j.Freelancer)
                      .WithMany(f => f.WorkingHistory)
                      .HasForeignKey(j => j.FreelancerId);

                entity.HasOne(j => j.Category)
                     .WithMany(c => c.Jobs)
                     .HasForeignKey(j => j.CategoryId);

                // map relation with skills >> M:M
                //entity.HasMany(j => j.skills)
                //      .WithMany(s => s.jobs)
                //      .UsingEntity<Dictionary<string, object>>("jobSkills",
                //    j => j.HasOne<Skill>()
                //          .WithMany()
                //          .HasForeignKey("SkillId"),
                //    j => j.HasOne<Job>()
                //          .WithMany()
                //          .HasForeignKey("JobId"));
            });

            modelBuilder.Entity<JobSkills>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.JobId });

                entity.HasOne(js => js.Job)
                      .WithMany(j => j.skills)
                      .HasForeignKey(js => js.JobId);

                entity.HasOne(js => js.Skill)
                       .WithMany(s => s.jobs)
                       .HasForeignKey(js => js.SkillId);
            });


            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Freelancer)
                     .WithMany(f => f.Portfolio)
                     .HasForeignKey(p => p.FreelancerId);

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
            });

            modelBuilder.Entity<ProjectSkills>(entity =>
            {
                entity.HasKey(e => new { e.SkillId, e.ProjectId });

                entity.HasOne(ps => ps.Project)
                      .WithMany(p => p.skills)
                      .HasForeignKey(ps => ps.ProjectId);

                entity.HasOne(ps => ps.Skill)
                       .WithMany(s => s.projects)
                       .HasForeignKey(ps => ps.SkillId);
            });

            modelBuilder.Entity<ProjectImages>(entity =>
            {
                entity.HasKey(pI => pI.Id);

                entity.HasOne(pI => pI.Project)
                     .WithMany(p => p.Images)
                     .HasForeignKey(pI => pI.ProjectId);
            });


            modelBuilder.Entity<Proposal>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Price)
                      .HasColumnType("Money");

                entity.Property(p => p.Status)
                      .HasDefaultValue(ProposalStatus.Waiting);

                entity.HasOne(p => p.Freelancer)
                      .WithMany(f => f.Proposals)
                      .HasForeignKey(p => p.FreelancerId);

                entity.HasOne(p => p.Job)
                      .WithMany(j => j.Proposals)
                      .HasForeignKey(p => p.JobId);
            });

            modelBuilder.Entity<IdentityRole>().HasData(
             new IdentityRole()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "Admin",
                 NormalizedName = "Admin".ToUpper(),
                 ConcurrencyStamp = Guid.NewGuid().ToString()
             },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Client",
                    NormalizedName = "Client".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                  new IdentityRole()
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "Freelancer",
                      NormalizedName = "Freelancer".ToUpper(),
                      ConcurrencyStamp = Guid.NewGuid().ToString()
                  }
             );

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasCheckConstraint("CK_VALUE_RANGE", "[Value] BETWEEN 1 AND 5");   // why warning??

                entity.HasOne(r => r.Job)
                     .WithOne(j => j.Rate)
                     .HasForeignKey<Rate>(r => r.JobId);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(c => c.Id);
            });


            //modelBuilder.Entity<FreelancerSkills>(entity =>
            //{
            //    entity.HasKey(fS => new { fS.FreelancerId, fS.SkillId });

            //    entity.HasMany(fS => fS.)
            //})


            //modelBuilder.Entity<JobSkills>()
            //   .HasKey(jS => new { jS.JobId, jS.SkillId });

            //modelBuilder.Entity<ProjectSkills>()
            //   .HasKey(pS => new { pS.ProjectId, pS.SkillId });


            #region Initial Data

            modelBuilder.Entity<Freelancer>().HasData
            (
                new Freelancer() { Id = 1, Name = "أحمد محمد", Title = "مطور الواجهة الخلفية" },
                new Freelancer() { Id = 2, Name = "علي سليمان", Title = "مطور الواجهة الأمامية" },
                new Freelancer() { Id = 3, Name = "وائل عبد الرحيم", Title = "مطور الواجهة الخلفية" }
            );

            modelBuilder.Entity<Skill>().HasData
         (
             new List<Skill>()
             {
                 new Skill() { Id = 1, Title = "C#" },
                 new Skill() { Id = 2, Title = "LINQ" },
                 new Skill() { Id = 3, Title = "EF" },
                 new Skill() { Id = 4, Title = "OOP" },
                 new Skill() { Id = 5, Title = "Agile" },
                 new Skill() { Id = 6, Title = "Blazor" },
             }
         );




            modelBuilder.Entity<Client>().HasData(
              new Client { Id = 1, Name = "Client1" },
              new Client { Id = 2, Name = "Client2" }
          );


            modelBuilder.Entity<Job>().HasData(
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

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Title = "Project1", Description = "Description for Project1", FreelancerId = 1, Poster = new byte[] { 0x20, 0x21, 0x22, 0x23 } },
                new Project { Id = 2, Title = "Project2", Description = "Description for Project2", FreelancerId = 2, Poster = new byte[] { 0x20, 0x21, 0x22, 0x23 } }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Category1" },
                new Category { Id = 2, Title = "Category2" }
            );

            modelBuilder.Entity<Proposal>().HasData(
                new Proposal { Id = 1, Price = 300, Status = ProposalStatus.Waiting, FreelancerId = 1, JobId = 1 },
                new Proposal { Id = 2, Price = 400, Status = ProposalStatus.Waiting, FreelancerId = 2, JobId = 2 }
            );

            modelBuilder.Entity<ProposalImages>().HasData(
              new ProposalImages { Id = 1, Image = new byte[] { 0x20, 0x21, 0x22, 0x23 }, ProposalId = 1 },
              new ProposalImages { Id = 2, Image = new byte[] { 0x20, 0x21, 0x22, 0x23 }, ProposalId = 2 }
          );

            modelBuilder.Entity<Rate>().HasData(
                new Rate { Id = 1, Value = 4, JobId = 1 },
                new Rate { Id = 2, Value = 5, JobId = 2 }
            );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
