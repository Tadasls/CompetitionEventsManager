using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class FixedlanguageinModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultComunicationLanguage",
                table: "LocalUsers",
                newName: "Language");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "LocalUsers",
                newName: "DefaultComunicationLanguage");
        }
    }
}
