using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.Challenge.Server.Migrations
{
    /// <inheritdoc />
    public partial class DriverLicenseCategoryAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseCategories",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "LicenseCategory",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08dbd59a-2683-4c67-8e16-689ba2648545"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 19, 56, 5, 262, DateTimeKind.Utc).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08dbdc08-56e1-4e90-805f-db29361e075e"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 19, 56, 5, 263, DateTimeKind.Utc).AddTicks(297));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseCategory",
                table: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "LicenseCategories",
                table: "Drivers",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08dbd59a-2683-4c67-8e16-689ba2648545"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 0, 46, 35, 210, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08dbdc08-56e1-4e90-805f-db29361e075e"),
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 0, 46, 35, 210, DateTimeKind.Utc).AddTicks(2780));
        }
    }
}
