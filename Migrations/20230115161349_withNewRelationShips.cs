using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class withNewRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Entries_HorseID",
                table: "Entries",
                column: "HorseID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_RiderID",
                table: "Entries",
                column: "RiderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Horses_HorseID",
                table: "Entries",
                column: "HorseID",
                principalTable: "Horses",
                principalColumn: "HorseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Riders_RiderID",
                table: "Entries",
                column: "RiderID",
                principalTable: "Riders",
                principalColumn: "RiderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Horses_HorseID",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Riders_RiderID",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_HorseID",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_RiderID",
                table: "Entries");
        }
    }
}
