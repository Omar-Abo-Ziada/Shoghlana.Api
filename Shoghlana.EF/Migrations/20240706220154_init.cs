using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    FreeLancerId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MinBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AcceptedFreelancerId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Jobs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Jobs_Freelancers_AcceptedFreelancerId",
                        column: x => x.AcceptedFreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    NotificationTriggerId = table.Column<int>(type: "int", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Freelancers_FreelancerId",
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
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TimePublished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FreelancerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FreelancerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSkills", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_JobSkills_Skills_SkillId1",
                        column: x => x.SkillId1,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Proposals_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    { "34af59c6-8ca2-46df-960f-f957feb5bdd4", "facd1893-9dd6-41ca-9ca9-05102ea72d86", "Freelancer", "FREELANCER" },
                    { "4767ba04-0cd8-459e-8e0b-0440dfa0ace7", "69dc1de9-2195-4a37-93ca-610d91245b3e", "Client", "CLIENT" },
                    { "493f6fd0-3be4-4d76-910c-6bafc1f3455b", "668df223-a931-422b-bc36-d3382c859494", "Admin", "ADMIN" }
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
                    { 1, "المملكة العربية السعودية", "مبرمج ومطور تطبيقات متخصص في تطوير الويب", null, "عبد الرحمن أحمد", "+966123456789", new DateTime(2024, 1, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2871) },
                    { 2, "مصر", "مصممة جرافيك محترفة تعمل في تصميم اللوجوهات والبوسترات", null, "فاطمة محمد", "+201234567890", new DateTime(2023, 7, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2920) },
                    { 3, "الإمارات العربية المتحدة", "مسوق رقمي محترف بخبرة في إدارة الحملات الإعلانية عبر وسائل التواصل الاجتماعي", null, "علي العبدالله", "+971123456789", new DateTime(2024, 4, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2924) },
                    { 4, "الأردن", "كاتبة محتوى متخصصة في الكتابة الإبداعية والمقالات الفنية", null, "مريم حسن", "+962123456789", new DateTime(2023, 10, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2928) },
                    { 5, "العراق", "مصور فوتوغرافي متخصص في تصوير الأحداث والمناسبات الخاصة", null, "يوسف خالد", "+964123456789", new DateTime(2023, 12, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2931) },
                    { 6, "السعودية", "مديرة مشروع محترفة في إدارة المشاريع التقنية والتطوير البرمجي", null, "لمى عبدالله", "+966123456789", new DateTime(2024, 3, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2934) },
                    { 7, "مصر", "مسوق محتوى إبداعي يعمل على ترويج المحتوى الرقمي للشركات الناشئة", null, "عمر أحمد", "+201234567890", new DateTime(2023, 8, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2938) },
                    { 8, "لبنان", "مطورة تطبيقات محترفة تعمل في تطوير تطبيقات الهواتف الذكية", null, "رنا محمود", "+961123456789", new DateTime(2023, 11, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2941) },
                    { 9, "الأردن", "مدير تسويق متخصص في إدارة استراتيجيات التسويق الرقمي", null, "أحمد علي", "+962123456789", new DateTime(2024, 2, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2944) },
                    { 10, "السعودية", "خبيرة في تصميم وإدارة مواقع الويب للشركات الصغيرة والمتوسطة", null, "هدى صالح", "+966123456789", new DateTime(2023, 9, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2948) },
                    { 11, "الإمارات العربية المتحدة", "محاسبة مالية محترفة تعمل في مجال إعداد التقارير المالية", null, "سلمى عبدالله", "+971123456789", new DateTime(2024, 4, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2951) },
                    { 12, "مصر", "مهندس معماري متخصص في تصميم المباني السكنية", null, "محمد حسن", "+201234567890", new DateTime(2023, 12, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2955) },
                    { 13, "العراق", "طبيبة مختصة في طب الأطفال والأمراض النفسية", null, "زينب عبدالله", "+964123456789", new DateTime(2024, 5, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2958) },
                    { 14, "لبنان", "مصمم جرافيك مبدع يعمل في تصميم الإعلانات التجارية", null, "أحمد حسين", "+961123456789", new DateTime(2023, 10, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2961) },
                    { 15, "الأردن", "مترجمة محترفة تعمل في ترجمة النصوص الطبية والعلمية", null, "فاطمة علي", "+962123456789", new DateTime(2024, 2, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2965) },
                    { 16, "السعودية", "مطور ويب محترف في تطوير التطبيقات الإلكترونية", null, "عبدالله محمود", "+966123456789", new DateTime(2023, 8, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2968) },
                    { 17, "مصر", "مهندسة معمارية متخصصة في تصميم المنشآت الصناعية", null, "ريم عبدالله", "+201234567890", new DateTime(2023, 11, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2972) },
                    { 18, "لبنان", "محاسب مالي يتمتع بخبرة واسعة في المحاسبة المالية", null, "عمر حسن", "+961123456789", new DateTime(2024, 3, 7, 1, 1, 53, 338, DateTimeKind.Local).AddTicks(2975) }
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
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1, "تصميم وأعمال فنية احترافية", 0, 0, 500m, 100m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1204), "تصميم شعار احترافي ومميز" },
                    { 2, 2, null, 1, 2, "تصميم وأعمال فنية إدارية", 0, 1, 700m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1215), "تصميم بوستر إعلاني لمواقع التواصل" },
                    { 3, 3, null, 1, 3, "تصميم بطاقات أعمال", 0, 2, 600m, 150m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1222), "تصميم كارت شخصي احترافي للطباعة" },
                    { 4, 4, null, 2, 4, "برمجة وتطوير المواقع والتطبيقات", 0, 1, 800m, 300m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1228), "تركيب لوحة تحكم مجانية مدى الحياة" },
                    { 5, 5, null, 3, 5, "برمجة مواقع الإنترنت", 0, 0, 700m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1233), "تصميم موقع تعريفي للشركات" },
                    { 6, 6, null, 4, 6, "برمجة وتصميم تطبيقات الهواتف الذكية", 0, 2, 3000m, 1000m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1240), "تطوير تطبيق موبايل لنظام iOS و Android" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Status", "Title" },
                values: new object[,]
                {
                    { 7, 7, null, 3, 7, "برمجة وتصميم مواقع التسوق عبر الإنترنت", 0, 1, 1500m, 500m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1318), 2, "تصميم وتطوير موقع تجارة إلكترونية" },
                    { 8, 8, null, 5, 8, "تسويق وإعلان للشركات والأفراد", 0, 0, 1000m, 300m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1325), 2, "إدارة حملة إعلانية على وسائل التواصل الاجتماعي" },
                    { 9, 9, null, 6, 9, "فنون تصويرية ورسم", 0, 1, 600m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1331), 2, "تصميم مجموعة من الرسوم التوضيحية للكتب الأطفال" },
                    { 10, 10, null, 1, 10, "كتابة محتوى تسويقي وإعلاني", 0, 0, 300m, 100m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1336), 2, "كتابة محتوى إعلاني لموقع الويب" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 11, null, null, 2, 11, "برمجة نظم إدارية متقدمة", 0, 2, 2000m, 500m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1342), "تصميم وبرمجة نظام إدارة للموظفين" },
                    { 12, null, null, 3, 12, "تحليل اقتصادي ومالي", 0, 2, 5000m, 1000m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1347), "إعداد دراسة جدوى لمشروع تجاري مستقبلي" },
                    { 13, null, null, 4, 13, "دورات تعليمية وتدريب", 0, 0, 200m, 50m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1352), "تعليم البرمجة للمبتدئين عبر الإنترنت" },
                    { 14, null, null, 5, 14, "تصميم جرافيك وإعلان", 0, 1, 500m, 150m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1358), "تصميم مطبوعات دعائية لفعالية ثقافية" },
                    { 15, null, null, 6, 15, "ترجمة وكتابة", 0, 2, 800m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1364), "ترجمة مقالات علمية من الإنجليزية إلى العربية" },
                    { 16, null, null, 1, 16, "برمجة ألعاب الفيديو", 0, 2, 5000m, 1000m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1369), "تصميم وتطوير لعبة فيديو متنقلة" },
                    { 17, null, null, 2, 17, "تصميم وبرمجة منصات تعليمية إلكترونية", 0, 1, 1500m, 500m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1374), "تصميم منصة تعليمية عبر الإنترنت" },
                    { 18, null, null, 3, 18, "كتابة وتحرير محتوى", 0, 1, 700m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1379), "إدارة محتوى لمدونة تقنية" },
                    { 19, null, null, 4, 1, "برمجة وتخصيص نظم CRM", 0, 2, 2500m, 800m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1389), "تصميم وتطوير نظام إدارة العلاقات مع العملاء (CRM)" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Status", "Title" },
                values: new object[,]
                {
                    { 20, null, null, 5, 2, "تحليل بيانات وإعداد تقارير", 0, 1, 1000m, 300m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1395), 1, "تحليل بيانات وإعداد تقرير استراتيجي للشركات" },
                    { 21, null, null, 6, 3, "كتابة محتوى تعليمي وبحثي", 0, 2, 1500m, 500m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1401), 1, "كتابة وتحرير كتب إلكترونية في مجال الذكاء الاصطناعي" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 22, null, null, 1, 4, "برمجة وتصميم مواقع تعليمية", 0, 1, 1200m, 400m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1406), "تصميم وتطوير موقع تعليمي للطلاب" },
                    { 23, null, null, 2, 5, "تصميم وبرمجة تطبيقات الحجز الإلكتروني", 0, 1, 1800m, 600m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1411), "تصميم وبرمجة منصة للحجز الإلكتروني للفعاليات" },
                    { 24, null, null, 3, 6, "تحسين أداء محركات البحث للمواقع", 0, 0, 800m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1419), "تحسين محركات البحث (SEO) لموقع الويب" },
                    { 25, null, null, 4, 7, "برمجة نظم إدارة متكاملة", 0, 2, 2500m, 700m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1425), "تطوير نظام لإدارة المخزون والمبيعات للشركات الصغيرة" },
                    { 26, null, null, 5, 8, "تحليل اقتصادي ومالي للمشاريع العقارية", 0, 2, 5000m, 1500m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1430), "إعداد دراسة جدوى لمشروع سكني جديد" },
                    { 27, null, null, 6, 9, "برمجة تطبيقات المساعدة الشخصية", 0, 2, 3000m, 800m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1435), "تصميم وتطوير تطبيق للمساعدة الشخصية عبر الإنترنت" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Status", "Title" },
                values: new object[,]
                {
                    { 28, null, null, 1, 10, "تسويق وجمع التبرعات", 0, 1, 1500m, 400m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1440), 1, "إنشاء وإدارة حملة تبرعات عبر الإنترنت" },
                    { 29, null, null, 2, 11, "تصميم وبرمجة منصات تعليمية تفاعلية", 0, 1, 2000m, 600m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1446), 1, "تطوير منصة تعليمية تفاعلية لتعليم الرياضيات" },
                    { 30, null, null, 3, 12, "برمجة وتصميم ألعاب تعليمية", 0, 0, 1200m, 300m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1451), 1, "تصميم وتطوير لعبة فيديو تعليمية للأطفال" },
                    { 31, null, null, 4, 13, "تحليل سياسات وإعداد تقارير", 0, 0, 700m, 200m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1456), 1, "إعداد تقرير بحثي عن السياسات العامة" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedFreelancerId", "ApproveTime", "CategoryId", "ClientId", "Description", "DurationInDays", "ExperienceLevel", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[,]
                {
                    { 32, null, null, 5, 14, "برمجة وتخصيص نظم إدارة المحتوى", 0, 1, 1500m, 400m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1463), "تصميم وبرمجة نظام إدارة المحتوى للمدونات" },
                    { 33, null, null, 6, 15, "تسويق وإعلان عن المنتجات", 0, 0, 1000m, 300m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1468), "إعداد وتنفيذ حملة تسويقية لمنتج جديد" },
                    { 34, null, null, 1, 16, "برمجة نظم إدارة المشاريع", 0, 2, 2500m, 600m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1474), "تصميم وبرمجة نظام لإدارة المشاريع الهندسية" },
                    { 35, null, null, 2, 17, "برمجة وتصميم تطبيقات تعليمية", 0, 1, 1800m, 500m, new DateTime(2024, 7, 7, 1, 1, 53, 341, DateTimeKind.Local).AddTicks(1479), "تصميم وتطوير تطبيق لتعليم لغات البرمجة" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "FreelancerId", "Link", "Poster", "TimePublished", "Title" },
                values: new object[,]
                {
                    { 1, "Description for Project1", 1, null, new byte[] { 32, 33, 34, 35 }, new DateTime(2024, 7, 7, 1, 1, 53, 342, DateTimeKind.Local).AddTicks(346), "Project1" },
                    { 2, "Description for Project2", 2, null, new byte[] { 32, 33, 34, 35 }, new DateTime(2024, 7, 7, 1, 1, 53, 342, DateTimeKind.Local).AddTicks(395), "Project2" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "ApprovedTime", "DeadLine", "Description", "Duration", "FreelancerId", "JobId", "Price", "ReposLinks", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 1, 1, 300m, null, 1 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0.0, 2, 2, 400m, null, 1 }
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
                name: "IX_FreelancerSkills_FreelancerId",
                table: "FreelancerSkills",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AcceptedFreelancerId",
                table: "Jobs",
                column: "AcceptedFreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ClientId",
                table: "Jobs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId1",
                table: "JobSkills",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ClientId",
                table: "Notifications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FreelancerId",
                table: "Notifications",
                column: "FreelancerId");

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
                name: "FreelancerSkills");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "Notifications");

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
