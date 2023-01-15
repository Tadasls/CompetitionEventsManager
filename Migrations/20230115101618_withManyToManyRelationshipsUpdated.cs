using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class withManyToManyRelationshipsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Competitions_SId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_SId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "SId",
                table: "Competitions");

            migrationBuilder.CreateTable(
                name: "CompetionStaff",
                columns: table => new
                {
                    CompetitionsCompetitionID = table.Column<int>(type: "INTEGER", nullable: false),
                    StaffsStaffID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetionStaff", x => new { x.CompetitionsCompetitionID, x.StaffsStaffID });
                    table.ForeignKey(
                        name: "FK_CompetionStaff_Competitions_CompetitionsCompetitionID",
                        column: x => x.CompetitionsCompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetionStaff_Staffs_StaffsStaffID",
                        column: x => x.StaffsStaffID,
                        principalTable: "Staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetionStaff_StaffsStaffID",
                table: "CompetionStaff",
                column: "StaffsStaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetionStaff");

            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "Staffs",
                type: "INTEGER",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SId",
                table: "Competitions",
                type: "INTEGER",
                maxLength: 20,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "CompetitionID",
                keyValue: 1,
                column: "SId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "CompetitionID",
                keyValue: 2,
                column: "SId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Competitions",
                keyColumn: "CompetitionID",
                keyValue: 3,
                column: "SId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffID",
                keyValue: 1,
                column: "SId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffID",
                keyValue: 2,
                column: "SId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "StaffID",
                keyValue: 3,
                column: "SId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SId",
                table: "Staffs",
                column: "SId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Competitions_SId",
                table: "Staffs",
                column: "SId",
                principalTable: "Competitions",
                principalColumn: "CompetitionID");
        }
    }
}
