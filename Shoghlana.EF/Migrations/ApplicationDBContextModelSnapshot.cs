﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shoghlana.EF;

#nullable disable

namespace Shoghlana.EF.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shoghlana.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Freelancer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PersonalImageBytes")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Freelancers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "أحمد محمد",
                            Title = "مطور الواجهة الخلفية"
                        },
                        new
                        {
                            Id = 2,
                            Name = "علي سليمان",
                            Title = "مطور الواجهة الأمامية"
                        },
                        new
                        {
                            Id = 3,
                            Name = "وائل عبد الرحيم",
                            Title = "مطور الواجهة الخلفية"
                        });
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExperienceLevel")
                        .HasColumnType("int");

                    b.Property<int?>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxBudget")
                        .HasColumnType("Money");

                    b.Property<decimal>("MinBudget")
                        .HasColumnType("Money");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClientId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("sentTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TimePublished")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.ProjectImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectImages");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("JobId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobId")
                        .IsUnique()
                        .HasFilter("[JobId] IS NOT NULL");

                    b.ToTable("Rates", t =>
                        {
                            t.HasCheckConstraint("CK_VALUE_RANGE", "[Value] BETWEEN 1 AND 5");
                        });
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Title = "LINQ"
                        },
                        new
                        {
                            Id = 3,
                            Title = "EF"
                        },
                        new
                        {
                            Id = 4,
                            Title = "OOP"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Agile"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Blazor"
                        });
                });

            modelBuilder.Entity("freelancerSkills", b =>
                {
                    b.Property<int>("FreelancerId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("FreelancerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("freelancerSkills");
                });

            modelBuilder.Entity("jobSkills", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("JobId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("jobSkills");
                });

            modelBuilder.Entity("projectSkills", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("projectSkills");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Job", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Category", "Category")
                        .WithMany("Jobs")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Shoghlana.Core.Models.Client", "Client")
                        .WithMany("Jobs")
                        .HasForeignKey("ClientId");

                    b.HasOne("Shoghlana.Core.Models.Freelancer", "Freelancer")
                        .WithMany("WorkingHistory")
                        .HasForeignKey("FreelancerId");

                    b.Navigation("Category");

                    b.Navigation("Client");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Notification", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Client", null)
                        .WithMany("notifications")
                        .HasForeignKey("ClientId");

                    b.HasOne("Shoghlana.Core.Models.Freelancer", null)
                        .WithMany("notifications")
                        .HasForeignKey("FreelancerId");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Project", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Freelancer", "Freelancer")
                        .WithMany("Portfolio")
                        .HasForeignKey("FreelancerId");

                    b.Navigation("Freelancer");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.ProjectImages", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Project", "Project")
                        .WithMany("Images")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Proposal", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Freelancer", "Freelancer")
                        .WithMany("Proposals")
                        .HasForeignKey("FreelancerId");

                    b.HasOne("Shoghlana.Core.Models.Job", "Job")
                        .WithMany("Proposals")
                        .HasForeignKey("JobId");

                    b.Navigation("Freelancer");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Rate", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Job", "Job")
                        .WithOne("Rate")
                        .HasForeignKey("Shoghlana.Core.Models.Rate", "JobId");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("freelancerSkills", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Freelancer", null)
                        .WithMany()
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoghlana.Core.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("jobSkills", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Job", null)
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoghlana.Core.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("projectSkills", b =>
                {
                    b.HasOne("Shoghlana.Core.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoghlana.Core.Models.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Category", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Client", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("notifications");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Freelancer", b =>
                {
                    b.Navigation("Portfolio");

                    b.Navigation("Proposals");

                    b.Navigation("WorkingHistory");

                    b.Navigation("notifications");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Job", b =>
                {
                    b.Navigation("Proposals");

                    b.Navigation("Rate");
                });

            modelBuilder.Entity("Shoghlana.Core.Models.Project", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
