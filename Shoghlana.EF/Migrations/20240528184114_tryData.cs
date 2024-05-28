using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class tryData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "freelancerSkills");

            migrationBuilder.DropTable(
                name: "projectSkills");

            migrationBuilder.DropCheckConstraint(
                name: "CK_VALUE_RANGE",
                table: "Rates");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Proposals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Proposals",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.CreateTable(
                name: "FreelancerSkill",
                columns: table => new
                {
                    freelancersId = table.Column<int>(type: "int", nullable: false),
                    skillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerSkill", x => new { x.freelancersId, x.skillsId });
                    table.ForeignKey(
                        name: "FK_FreelancerSkill_Freelancers_freelancersId",
                        column: x => x.freelancersId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreelancerSkill_Skills_skillsId",
                        column: x => x.skillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    projectsId = table.Column<int>(type: "int", nullable: false),
                    skillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.projectsId, x.skillsId });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_skillsId",
                        column: x => x.skillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CategoryId", "ClientId", "Description", "ExperienceLevel", "FreelancerId", "MaxBudget", "MinBudget", "PostTime", "Title" },
                values: new object[] { 1, null, 1, "Develop software applications", 1, null, 2000m, 1000m, new DateTime(2024, 5, 28, 21, 41, 11, 565, DateTimeKind.Local).AddTicks(2382), "Software Developer" });

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerSkill_skillsId",
                table: "FreelancerSkill",
                column: "skillsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_skillsId",
                table: "ProjectSkill",
                column: "skillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreelancerSkill");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Proposals",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Proposals",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "freelancerSkills",
                columns: table => new
                {
                    FreelancerId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freelancerSkills", x => new { x.FreelancerId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_freelancerSkills_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_freelancerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectSkills",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectSkills", x => new { x.ProjectId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_projectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_VALUE_RANGE",
                table: "Rates",
                sql: "[Value] BETWEEN 1 AND 5");

            migrationBuilder.CreateIndex(
                name: "IX_freelancerSkills_SkillId",
                table: "freelancerSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_projectSkills_SkillId",
                table: "projectSkills",
                column: "SkillId");
        }
    }
}
