using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProposalFKNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalImages_Proposals_ProposalId",
                table: "ProposalImages");

            migrationBuilder.AlterColumn<int>(
                name: "ProposalId",
                table: "ProposalImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 20, 58, 53, 362, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 20, 58, 53, 362, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalImages_Proposals_ProposalId",
                table: "ProposalImages",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProposalImages_Proposals_ProposalId",
                table: "ProposalImages");

            migrationBuilder.AlterColumn<int>(
                name: "ProposalId",
                table: "ProposalImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 12, 53, 36, 655, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 1, 12, 53, 36, 655, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.AddForeignKey(
                name: "FK_ProposalImages_Proposals_ProposalId",
                table: "ProposalImages",
                column: "ProposalId",
                principalTable: "Proposals",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
