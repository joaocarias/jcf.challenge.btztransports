using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jcf.Challenge.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "Name", "Password", "RemovedAt", "Role", "UpdatedAt", "UserCreateId", "UserName", "UserUpdateId" },
                values: new object[,]
                {
                    { new Guid("08dbd59a-2683-4c67-8e16-689ba2648545"), new DateTime(2023, 11, 12, 0, 46, 35, 210, DateTimeKind.Utc).AddTicks(2221), "admin@email.com", true, "Administrador Usuário", "4BADAEE57FED5610012A296273158F5F", null, "ADMIN", null, null, "admin@email.com", null },
                    { new Guid("08dbdc08-56e1-4e90-805f-db29361e075e"), new DateTime(2023, 11, 12, 0, 46, 35, 210, DateTimeKind.Utc).AddTicks(2780), "basico@email.com", true, "Básico Usuário", "4BADAEE57FED5610012A296273158F5F", null, "BASIC", null, null, "basico@email.com", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08dbd59a-2683-4c67-8e16-689ba2648545"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("08dbdc08-56e1-4e90-805f-db29361e075e"));
        }
    }
}
