using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shoghlana.EF.Migrations
{
    /// <inheritdoc />
    public partial class JobSkillsCompositePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deleting old roles (if necessary)
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d23a58f-175a-4531-abbc-8c3a72433f8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0233c3d-cdb9-42d7-b2ab-72dc60de1efe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f916ac27-9a5e-4b77-bae9-56f9d1faf9a0");

            // Inserting new roles, only if they do not already exist
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [NormalizedName] = 'FREELANCER')
        BEGIN
            INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
            VALUES (N'4fe832e6-8cbf-498e-8db0-a31f81ab5566', N'32caf5e8-522a-4e29-825b-b1e697766176', N'Freelancer', N'FREELANCER')
        END;
        
        IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [NormalizedName] = 'ADMIN')
        BEGIN
            INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
            VALUES (N'88bc3e52-97dd-4fdf-a92a-a607cb73de3f', N'364c023b-2bf9-43ce-b4f3-687ee8fa1d1b', N'Admin', N'ADMIN')
        END;
        
        IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [NormalizedName] = 'CLIENT')
        BEGIN
            INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
            VALUES (N'f00a10ff-acae-4832-9eb0-82e4befe0ba7', N'915dc2d7-cf43-49c0-9588-6f927da5a0c1', N'Client', N'CLIENT')
        END;
    ");

            // Updating the post time in the Jobs table
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 16, 22, 19, 23, 430, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 16, 22, 19, 23, 430, DateTimeKind.Local).AddTicks(7956));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Deleting the new roles inserted in the Up method
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe832e6-8cbf-498e-8db0-a31f81ab5566");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88bc3e52-97dd-4fdf-a92a-a607cb73de3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f00a10ff-acae-4832-9eb0-82e4befe0ba7");

            // Re-inserting the old roles
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
            { "4d23a58f-175a-4531-abbc-8c3a72433f8e", "371f05e3-8de1-427d-bf8a-2dca118c3cf7", "Freelancer", "FREELANCER" },
            { "b0233c3d-cdb9-42d7-b2ab-72dc60de1efe", "c6a2169f-e576-481d-b290-1f84f974667b", "Client", "CLIENT" },
            { "f916ac27-9a5e-4b77-bae9-56f9d1faf9a0", "2bc7f31e-7f80-415f-ad9a-9cd71f15c0f0", "Admin", "ADMIN" }
                });

            // Reverting the post time updates in the Jobs table
            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostTime",
                value: new DateTime(2024, 6, 16, 22, 7, 49, 255, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostTime",
                value: new DateTime(2024, 6, 16, 22, 7, 49, 255, DateTimeKind.Local).AddTicks(2617));
        }
    }
}
