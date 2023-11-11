using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.Challenge.Server.Migrations
{
    /// <inheritdoc />
    public partial class VehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserUpdateId",
                table: "Users",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "UserUpdateId",
                table: "Drivers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Plate = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YearManufacture = table.Column<int>(type: "int", nullable: false),
                    MaxCapacityFuel = table.Column<double>(type: "double", nullable: false),
                    Observation = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RemovedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserCreateId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserUpdateId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserUpdateId",
                        column: x => x.UserUpdateId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserUpdateId",
                table: "Users",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserUpdateId",
                table: "Drivers",
                column: "UserUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserCreateId",
                table: "Vehicles",
                column: "UserCreateId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserUpdateId",
                table: "Vehicles",
                column: "UserUpdateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Users_UserUpdateId",
                table: "Drivers",
                column: "UserUpdateId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserUpdateId",
                table: "Users",
                column: "UserUpdateId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Users_UserUpdateId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserUpdateId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserUpdateId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_UserUpdateId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "UserUpdateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserUpdateId",
                table: "Drivers");
        }
    }
}
