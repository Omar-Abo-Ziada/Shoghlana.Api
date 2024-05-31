using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class ApplicationDBContext :  IdentityDbContext<ApplicationUser>

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

            //modelBuilder.Entity<Client>(entity =>
            //{
            //    entity.HasKey(c => c.Id);
            //});


            modelBuilder.Entity<Freelancer>(entity =>
            {
                //entity.HasKey(f => f.Id);

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
                entity.HasMany(j => j.skills)
                      .WithMany(s => s.jobs)
                      .UsingEntity<Dictionary<string, object>>("jobSkills",
                    j => j.HasOne<Skill>()
                          .WithMany()
                          .HasForeignKey("SkillId"),
                    j => j.HasOne<Job>()
                          .WithMany()
                          .HasForeignKey("JobId"));
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Freelancer)
                     .WithMany(f => f.Portfolio)
                     .HasForeignKey(p => p.FreelancerId);

                // map relation with skills >> M:M
                entity.HasMany(p => p.skills)
                      .WithMany(s => s.projects)
                      .UsingEntity<Dictionary<string, object>>("projectSkills",
                    j => j.HasOne<Skill>()
                          .WithMany()
                          .HasForeignKey("SkillId"),
                    j => j.HasOne<Project>()
                          .WithMany()
                          .HasForeignKey("ProjectId"));
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


            base.OnModelCreating(modelBuilder);


        }
    }
}
