using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class fixedRelationshipsAtEntryLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Competitions_CompetitionID",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_LocalUsers_LocalUserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_CompetitionID",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_LocalUserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "CompetitionID",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "LocalUserId",
                table: "Entries");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CId",
                table: "Entries",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                table: "Entries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Competitions_CId",
                table: "Entries",
                column: "CId",
                principalTable: "Competitions",
                principalColumn: "CompetitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_LocalUsers_UserId",
                table: "Entries",
                column: "UserId",
                principalTable: "LocalUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Competitions_CId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_LocalUsers_UserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_CId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionID",
                table: "Entries",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalUserId",
                table: "Entries",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumns: new[] { "HorseID", "RiderID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CompetitionID", "LocalUserId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumns: new[] { "HorseID", "RiderID" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CompetitionID", "LocalUserId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Entries",
                keyColumns: new[] { "HorseID", "RiderID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "CompetitionID", "LocalUserId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CompetitionID",
                table: "Entries",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_LocalUserId",
                table: "Entries",
                column: "LocalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Competitions_CompetitionID",
                table: "Entries",
                column: "CompetitionID",
                principalTable: "Competitions",
                principalColumn: "CompetitionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_LocalUsers_LocalUserId",
                table: "Entries",
                column: "LocalUserId",
                principalTable: "LocalUsers",
                principalColumn: "Id");
        }
    }
}
