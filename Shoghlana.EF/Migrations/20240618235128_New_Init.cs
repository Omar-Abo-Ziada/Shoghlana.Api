﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class New_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisterationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalImageBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientNotifications",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientNotifications", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_ClientNotifications_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    FreeLancerId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Freelancers_FreeLancerId",
                        column: x => x.FreeLancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreelancerNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreelancerNotifications_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Jobs_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TimePublished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FreelancerSkills",
                columns: table => new
                {
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkills", x => new { x.SkillId, x.FreelancerId });
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.ApplicationUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ReposLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposals_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.CheckConstraint("CK_VALUE_RANGE", "[Value] BETWEEN 1 AND 5");
                    table.ForeignKey(
                        name: "FK_Rates_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectImages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => new { x.SkillId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProposalImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProposalImages_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1734c1e3-5aa2-4e82-abe1-f6ffb73e5de0", "12d41127-948c-45b0-9ede-da81f663da7a", "Freelancer", "FREELANCER" },
                    { "bec88b87-a5e2-46a1-bd94-4533e847aaea", "7536f748-cc18-4b00-9049-b3a0512fbc4c", "Client", "CLIENT" },
                    { "dc0f20d8-c273-42f6-becd-dbcbbc0ac3e9", "15225215-34f6-48b7-a4f2-49de1555179c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "تشمل كافة الخدمات المتعلقة بالتصميم الجرافيكي، التصميم الصناعي، وتصميم الويب.", "خدمات التصميم" },
                    { 2, "تشمل كتابة وتطوير التطبيقات والبرمجيات لمختلف الأنظمة والأجهزة.", "خدمات برمجية" },
                    { 3, "تشمل كتابة المقالات، الترجمة الفورية، وكتابة المحتوى للمواقع والمدونات.", "خدمات الكتابة والترجمة" },
                    { 4, "تشمل إدارة حملات التسويق الرقمي، الإعلانات على وسائل التواصل الاجتماعي، وتحليلات السوق.", "خدمات التسويق الرقمي" },
                    { 5, "تشمل دعم المستخدمين، إصلاح الأعطال التقنية، وتحسين أداء النظم والشبكات.", "خدمات الدعم الفني والتقني" },
                    { 6, "تشمل تقديم دورات تدريبية، تصميم مناهج تعليمية، وتطوير الموارد التعليمية.", "خدمات التعليم والتدريب" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Country", "Description", "Image", "Name", "Phone", "RegisterationTime" },
                values: new object[,]
                {
                    { 1, "المملكة العربية السعودية", "مبرمج ومطور تطبيقات متخصص في تطوير الويب", null, "عبد الرحمن أحمد", "+966123456789", new DateTime(2023, 12, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6436) },
                    { 2, "مصر", "مصممة جرافيك محترفة تعمل في تصميم اللوجوهات والبوسترات", null, "فاطمة محمد", "+201234567890", new DateTime(2023, 6, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6516) },
                    { 3, "الإمارات العربية المتحدة", "مسوق رقمي محترف بخبرة في إدارة الحملات الإعلانية عبر وسائل التواصل الاجتماعي", null, "علي العبدالله", "+971123456789", new DateTime(2024, 3, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6521) },
                    { 4, "الأردن", "كاتبة محتوى متخصصة في الكتابة الإبداعية والمقالات الفنية", null, "مريم حسن", "+962123456789", new DateTime(2023, 9, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6526) },
                    { 5, "العراق", "مصور فوتوغرافي متخصص في تصوير الأحداث والمناسبات الخاصة", null, "يوسف خالد", "+964123456789", new DateTime(2023, 11, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6530) },
                    { 6, "السعودية", "مديرة مشروع محترفة في إدارة المشاريع التقنية والتطوير البرمجي", null, "لمى عبدالله", "+966123456789", new DateTime(2024, 2, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6534) },
                    { 7, "مصر", "مسوق محتوى إبداعي يعمل على ترويج المحتوى الرقمي للشركات الناشئة", null, "عمر أحمد", "+201234567890", new DateTime(2023, 7, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6539) },
                    { 8, "لبنان", "مطورة تطبيقات محترفة تعمل في تطوير تطبيقات الهواتف الذكية", null, "رنا محمود", "+961123456789", new DateTime(2023, 10, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6542) },
                    { 9, "الأردن", "مدير تسويق متخصص في إدارة استراتيجيات التسويق الرقمي", null, "أحمد علي", "+962123456789", new DateTime(2024, 1, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6546) },
                    { 10, "السعودية", "خبيرة في تصميم وإدارة مواقع الويب للشركات الصغيرة والمتوسطة", null, "هدى صالح", "+966123456789", new DateTime(2023, 8, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6551) },
                    { 11, "الإمارات العربية المتحدة", "محاسبة مالية محترفة تعمل في مجال إعداد التقارير المالية", null, "سلمى عبدالله", "+971123456789", new DateTime(2024, 3, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6554) },
                    { 12, "مصر", "مهندس معماري متخصص في تصميم المباني السكنية", null, "محمد حسن", "+201234567890", new DateTime(2023, 11, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6558) },
                    { 13, "العراق", "طبيبة مختصة في طب الأطفال والأمراض النفسية", null, "زينب عبدالله", "+964123456789", new DateTime(2024, 4, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6562) },
                    { 14, "لبنان", "مصمم جرافيك مبدع يعمل في تصميم الإعلانات التجارية", null, "أحمد حسين", "+961123456789", new DateTime(2023, 9, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6566) },
                    { 15, "الأردن", "مترجمة محترفة تعمل في ترجمة النصوص الطبية والعلمية", null, "فاطمة علي", "+962123456789", new DateTime(2024, 1, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6570) },
                    { 16, "السعودية", "مطور ويب محترف في تطوير التطبيقات الإلكترونية", null, "عبدالله محمود", "+966123456789", new DateTime(2023, 7, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6574) },
                    { 17, "مصر", "مهندسة معمارية متخصصة في تصميم المنشآت الصناعية", null, "ريم عبدالله", "+201234567890", new DateTime(2023, 10, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6578) },
                    { 18, "لبنان", "محاسب مالي يتمتع بخبرة واسعة في المحاسبة المالية", null, "عمر حسن", "+961123456789", new DateTime(2024, 2, 19, 2, 51, 26, 789, DateTimeKind.Local).AddTicks(6583) }
                });

            migrationBuilder.InsertData(
                table: "Freelancers",
                columns: new[] { "Id", "Address", "Name", "Overview", "PersonalImageBytes", "Title" },
                values: new object[,]
                {
                    { 1, "القاهرة، مصر", "محمد أحمد", "مطور محترف بخبرة في تطوير تطبيقات الويب والهواتف الذكية", null, "مطور تطبيقات متخصص" },
                    { 2, "الرياض، السعودية", "فاطمة علي", "مصممة ذات خبرة عالية في تصميم الشعارات والبوسترات", null, "مصممة جرافيك محترفة" },
                    { 3, "القاهرة، مصر", "أحمد خالد", "مبرمج ذو خبرة في تطوير التطبيقات المتقدمة باستخدام تقنيات الذكاء الاصطناعي", null, "مبرمج متخصص في الذكاء الاصطناعي" },
                    { 4, "دبي، الإمارات", "سارة حسين", "مصممة جرافيك بخبرة في التصميم التجريدي والفنون الإبداعية", null, "مصممة تجريدية ومبدعة" },
                    { 5, "الإسكندرية، مصر", "عبد الرحمن محمود", "مطور محترف بخبرة في بناء وتطوير المواقع الإلكترونية الكبيرة والمعقدة", null, "مطور مواقع إلكترونية متقدم" },
                    { 6, "جدة، السعودية", "ريما عبدالله", "مصممة جرافيك بخبرة واسعة في تصميم الشعارات والهويات التجارية", null, "مصممة جرافيك احترافية" },
                    { 7, "القاهرة، مصر", "محمود علي", "مطور متخصص بخبرة في تطوير تطبيقات الهواتف الذكية باستخدام أحدث التقنيات", null, "مطور تطبيقات متخصص في الهواتف الذكية" },
                    { 8, "الرياض، السعودية", "نور عبدالله", "مطورة بخبرة في تطوير تطبيقات الويب والهواتف الذكية بتقنيات متقدمة", null, "مطورة تطبيقات محترفة" },
                    { 9, "الإسكندرية، مصر", "ليلى محمد", "مصممة جرافيك وفنانة بخبرة في تصميم الرسومات والفنون التشكيلية", null, "مصممة جرافيك وفنانة مبدعة" },
                    { 10, "المنامة، البحرين", "علي الحسيني", "مطور بخبرة في تطوير تطبيقات الويب والهواتف الذكية باللغات المتعددة", null, "مطور تطبيقات إلكترونية" }
                });

            migrationBuilder.InsertData(
                table: "ProjectImages",
                columns: new[] { "Id", "Image", "ProjectId" },
                values: new object[,]
                {
                    { 1, new byte[] { 32, 33, 34, 35 }, null },
                    { 2, new byte[] { 32, 33, 34, 35 }, null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, null, "تصميم الجرافيك" },
                    { 2, null, "الرسم الصناعي" },
                    { 3, null, "تصميم الويب" },
                    { 4, null, "تصميم الهوية التجارية" },
                    { 5, null, "تصميم المنتجات" },
                    { 6, null, "تصميم الشعارات" },
                    { 7, null, "تطوير تطبيقات الجوال" },
                    { 8, null, "تطوير الويب" },
                    { 9, null, "تطوير الألعاب" },
                    { 10, null, "برمجة الحاسوب" },
                    { 11, null, "كتابة المحتوى" },
                    { 12, null, "كتابة المقالات" },
                    { 13, null, "الترجمة" },
                    { 14, null, "التدقيق اللغوي" },
                    { 15, null, "الكتابة الفنية" },
                    { 16, null, "التسويق الرقمي" },
                    { 17, null, "تحسين محركات البحث (SEO)" },
                    { 18, null, "الإعلانات عبر وسائل التواصل الاجتماعي" },
                    { 19, null, "التسويق بالبريد الإلكتروني" },
                    { 20, null, "التسويق بالمحتوى" },
                    { 21, null, "الدعم الفني" },
                    { 22, null, "إدارة الشبكات" },
                    { 23, null, "صيانة الأنظمة" },
                    { 24, null, "دعم سطح المكتب" },
                    { 25, null, "خدمات الحوسبة السحابية" },
                    { 26, null, "تطوير البرامج التعليمية" },
                    { 27, null, "تصميم المناهج الدراسية" },
                    { 28, null, "تطوير التعليم الإلكتروني" },
                    { 29, null, "تصميم الدروس التعليمية" },
                    { 30, null, "تعليم عبر الإنترنت" },
                    { 31, null, "تصميم الإعلانات" },
                    { 32, null, "تصميم واجهات المستخدم (UI)" },
                    { 33, null, "تجربة المستخدم (UX)" },
                    { 34, null, "نمذجة ثلاثية الأبعاد (3D)" },
                    { 35, null, "تصميم الشخصيات" },
                    { 36, null, "تطوير التطبيقات بواسطة React.js" },
                    { 37, null, "تطوير التطبيقات بواسطة Node.js" },
                    { 38, null, "تطوير التطبيقات بواسطة Ruby on Rails" },
                    { 39, null, "تطوير التطبيقات بواسطة SQL" },
                    { 40, null, "تطوير التطبيقات بواسطة Django" },
                    { 41, null, "كتابة المقالات القانونية" },
                    { 42, null, "الكتابة الإبداعية" },
                    { 43, null, "التحقق القانوني" },
                    { 44, null, "التعريب" },
                    { 45, null, "تحليل السوق" },
                    { 46, null, "التحليلات الإحصائية" },
                    { 47, null, "التسويق بالأداء" },
                    { 48, null, "التسويق بالشراكة" },
                    { 49, null, "التسويق الإلكتروني" },
                    { 50, null, "إدارة الحملات الإعلانية" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "ClientId", "Description", "ExperienceLevel", "FreelancerId", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, "تصميم وأعمال فنية احترافية", 0, 1, 500m, 100m, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(297), "تصميم شعار احترافي ومميز" },
                    { 2, 1, null, "تصميم وأعمال فنية إدارية", 1, 2, 700m, 200m, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(386), "تصميم بوستر إعلاني لمواقع التواصل" },
                    { 3, 1, null, "تصميم بطاقات أعمال", 2, 3, 600m, 150m, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(393), "تصميم كارت شخصي احترافي للطباعة" },
                    { 4, 2, null, "برمجة وتطوير المواقع والتطبيقات", 1, 4, 800m, 300m, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(399), "تركيب لوحة تحكم مجانية مدى الحياة" },
                    { 5, 3, null, "برمجة مواقع الإنترنت", 0, 5, 700m, 200m, new DateTime(2024, 6, 19, 2, 51, 26, 793, DateTimeKind.Local).AddTicks(405), "تصميم موقع تعريفي للشركات" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "FreelancerId", "Link", "Poster", "TimePublished", "Title" },
                values: new object[,]
                {
                    { 1, "Description for Project1", 1, null, new byte[] { 32, 33, 34, 35 }, null, "Project1" },
                    { 2, "Description for Project2", 2, null, new byte[] { 32, 33, 34, 35 }, null, "Project2" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "ApprovedTime", "DeadLine", "Description", "Duration", "FreelancerId", "JobId", "Price", "ReposLinks", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 1, 1, 300m, null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 2, 2, 400m, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "Feedback", "JobId", "Value" },
                values: new object[,]
                {
                    { 1, null, 1, 4 },
                    { 2, null, 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                unique: true,
                filter: "[AdminId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FreeLancerId",
                table: "AspNetUsers",
                column: "FreeLancerId",
                unique: true,
                filter: "[FreeLancerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerNotifications_FreelancerId",
                table: "FreelancerNotifications",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkills_FreelancerId",
                table: "FreelancerSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ClientId",
                table: "Jobs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FreelancerId",
                table: "Jobs",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ProjectId",
                table: "ProjectImages",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_FreelancerId",
                table: "Projects",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_ProjectId",
                table: "ProjectSkills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalImages_ProposalId",
                table: "ProposalImages",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_FreelancerId",
                table: "Proposals",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_JobId",
                table: "Proposals",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_JobId",
                table: "Rates",
                column: "JobId",
                unique: true,
                filter: "[JobId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientNotifications");

            migrationBuilder.DropTable(
                name: "FreelancerNotifications");

            migrationBuilder.DropTable(
                name: "FreelancerSkills");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "ProjectImages");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "ProposalImages");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Freelancers");
        }
    }
}
