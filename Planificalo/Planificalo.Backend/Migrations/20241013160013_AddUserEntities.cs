using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    public partial class AddUserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            // Drop the existing Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            // Add the new Id column with the desired properties
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Rename the table
            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            // Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            // Add other columns and constraints as needed
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // ... (other columns and constraints)

            // Create new tables and indexes
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

            // ... (other tables and indexes)
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the new tables and indexes
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            // ... (other tables and indexes)

            // Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            // Drop the new Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUsers");

            // Add the old Id column back
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AspNetUsers",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Rename the table back
            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            // Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            // ... (other columns and constraints)
        }
    }
}