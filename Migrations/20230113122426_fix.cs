using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Horses_HorseID",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Riders_RiderID",
                table: "Entries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumns: new[] { "HorseID", "RiderID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumns: new[] { "HorseID", "RiderID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumns: new[] { "HorseID", "RiderID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AlterColumn<int>(
                name: "EntryID",
                table: "Entries",
                type: "INTEGER",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "RiderID",
                table: "Entries",
                type: "INTEGER",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "HorseID",
                table: "Entries",
                type: "INTEGER",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                column: "EntryID");

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryID", "AgreemntOnContractNr1", "CId", "Comments", "HorseBirthYear", "HorseID", "HorseName", "NeedElectricity", "NeedInvoice", "NumberOfCages", "PlateNumbers", "Points", "RiderFullName", "RiderID", "Shavings", "Status", "StayFromDate", "StayToDate", "Time", "Training", "UserId" },
                values: new object[,]
                {
                    { 1, true, null, null, null, 1, "The King", false, false, 1, "KEK:511", 0, "Linas Balciunas", 1, false, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 0.0, false, null },
                    { 2, false, null, null, null, 2, "Perkunas", false, true, 2, "KEK:515", 0, "S Laurinaitis", 2, true, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 0.0, false, null },
                    { 3, true, null, null, null, 3, "Nabagute", true, false, 5, "", 0, "Z Sarka", 3, false, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), 0.0, true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entries_HorseID",
                table: "Entries",
                column: "HorseID");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_HorseID",
                table: "Entries");

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "EntryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "EntryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "EntryID",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "RiderID",
                table: "Entries",
                type: "INTEGER",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HorseID",
                table: "Entries",
                type: "INTEGER",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EntryID",
                table: "Entries",
                type: "INTEGER",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 20)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                columns: new[] { "HorseID", "RiderID" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "HorseID", "RiderID", "AgreemntOnContractNr1", "CId", "Comments", "EntryID", "HorseBirthYear", "HorseName", "NeedElectricity", "NeedInvoice", "NumberOfCages", "PlateNumbers", "Points", "RiderFullName", "Shavings", "Status", "StayFromDate", "StayToDate", "Time", "Training", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, null, null, 1, null, "The King", false, false, 1, "KEK:511", 0, "Linas Balciunas", false, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 0.0, false, null },
                    { 2, 2, false, null, null, 2, null, "Perkunas", false, true, 2, "KEK:515", 0, "S Laurinaitis", true, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 0.0, false, null },
                    { 3, 3, true, null, null, 3, null, "Nabagute", true, false, 5, "", 0, "Z Sarka", false, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), 0.0, true, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Horses_HorseID",
                table: "Entries",
                column: "HorseID",
                principalTable: "Horses",
                principalColumn: "HorseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Riders_RiderID",
                table: "Entries",
                column: "RiderID",
                principalTable: "Riders",
                principalColumn: "RiderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
