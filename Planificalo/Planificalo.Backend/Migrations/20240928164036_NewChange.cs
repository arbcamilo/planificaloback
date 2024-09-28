using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planificalo.Backend.Migrations
{
    /// <inheritdoc />
    public partial class NewChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
