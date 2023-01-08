using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class changeInModelName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Reservation_ReservationID",
                table: "Performance");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Performance",
                newName: "EntryID");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_ReservationID",
                table: "Performance",
                newName: "IX_Performance_EntryID");

            migrationBuilder.CreateTable(
                name: "Entry",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NeedElectricity = table.Column<bool>(type: "INTEGER", nullable: true),
                    PlateNumbers = table.Column<string>(type: "TEXT", nullable: true),
                    numberOfCages = table.Column<int>(type: "INTEGER", nullable: true),
                    StayFromDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StayToDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Shavings = table.Column<bool>(type: "INTEGER", nullable: true),
                    NeedInvoice = table.Column<bool>(type: "INTEGER", nullable: true),
                    AgreemntOnContractNr1 = table.Column<bool>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    LocalUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.EntryID);
                    table.ForeignKey(
                        name: "FK_Entry_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entry_LocalUserId",
                table: "Entry",
                column: "LocalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Entry_EntryID",
                table: "Performance",
                column: "EntryID",
                principalTable: "Entry",
                principalColumn: "EntryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Entry_EntryID",
                table: "Performance");

            migrationBuilder.DropTable(
                name: "Entry");

            migrationBuilder.RenameColumn(
                name: "EntryID",
                table: "Performance",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_EntryID",
                table: "Performance",
                newName: "IX_Performance_ReservationID");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgreemntOnContractNr1 = table.Column<bool>(type: "INTEGER", nullable: true),
                    LocalUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    NeedElectricity = table.Column<bool>(type: "INTEGER", nullable: true),
                    NeedInvoice = table.Column<bool>(type: "INTEGER", nullable: true),
                    PlateNumbers = table.Column<string>(type: "TEXT", nullable: true),
                    Shavings = table.Column<bool>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    StayFromDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StayToDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    numberOfCages = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocalUserId",
                table: "Reservation",
                column: "LocalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Reservation_ReservationID",
                table: "Performance",
                column: "ReservationID",
                principalTable: "Reservation",
                principalColumn: "ReservationID");
        }
    }
}
