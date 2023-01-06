using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class antrosdienospirmipakeitimai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "LocalUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "LocalUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "LocalUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "LocalUsers",
                newName: "Name");
        }
    }
}
