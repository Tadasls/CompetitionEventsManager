using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class fillModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornDate",
                table: "Horses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Riders",
                newName: "RiderID");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FEIID",
                table: "Riders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceExiprationDate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalUserId",
                table: "Riders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MedCheckDate",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalFederationID",
                table: "Riders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RidersClubName",
                table: "Riders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "LocalUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultComunicationLanguage",
                table: "LocalUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "LocalUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "LocalUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LocalUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Horses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Breeder",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChipNumber",
                table: "Horses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commets",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FEIID",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Father",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Heigth",
                table: "Horses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalUserId",
                table: "Horses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MedCheckDate",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mother",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatFedID",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportNo",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportNoExipreDate",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearOfBird",
                table: "Horses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    LocalUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notification_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.PrimaryKey("PK_Reservation", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservation_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    PerformanceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HorseID = table.Column<int>(type: "INTEGER", nullable: false),
                    RiderID = table.Column<int>(type: "INTEGER", nullable: false),
                    HorseName = table.Column<string>(type: "TEXT", nullable: true),
                    RiderFullName = table.Column<string>(type: "TEXT", nullable: true),
                    HorseBirthYear = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Points = table.Column<int>(type: "INTEGER", nullable: true),
                    Time = table.Column<double>(type: "REAL", nullable: true),
                    Training = table.Column<bool>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    TraiCommetsning = table.Column<string>(type: "TEXT", nullable: true),
                    ReservationID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.PerformanceID);
                    table.ForeignKey(
                        name: "FK_Performance_Horses_HorseID",
                        column: x => x.HorseID,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performance_Reservation_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservation",
                        principalColumn: "ReservationID");
                    table.ForeignKey(
                        name: "FK_Performance_Riders_RiderID",
                        column: x => x.RiderID,
                        principalTable: "Riders",
                        principalColumn: "RiderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Breed", "Breeder", "ChipNumber", "Color", "Commets", "FEIID", "Father", "Gender", "Heigth", "LocalUserId", "MedCheckDate", "Mother", "NatFedID", "PassportNo", "PassportNoExipreDate", "Type", "YearOfBird" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Breed", "Breeder", "ChipNumber", "Color", "Commets", "FEIID", "Father", "Gender", "Heigth", "LocalUserId", "MedCheckDate", "Mother", "NatFedID", "PassportNo", "PassportNoExipreDate", "Type", "YearOfBird" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Breed", "Breeder", "ChipNumber", "Color", "Commets", "FEIID", "Father", "Gender", "Heigth", "LocalUserId", "MedCheckDate", "Mother", "NatFedID", "PassportNo", "PassportNoExipreDate", "Type", "YearOfBird" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Riders_LocalUserId",
                table: "Riders",
                column: "LocalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_LocalUserId",
                table: "Horses",
                column: "LocalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_LocalUserId",
                table: "Notification",
                column: "LocalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_HorseID",
                table: "Performance",
                column: "HorseID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_ReservationID",
                table: "Performance",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_RiderID",
                table: "Performance",
                column: "RiderID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocalUserId",
                table: "Reservation",
                column: "LocalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_LocalUsers_LocalUserId",
                table: "Horses",
                column: "LocalUserId",
                principalTable: "LocalUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riders_LocalUsers_LocalUserId",
                table: "Riders",
                column: "LocalUserId",
                principalTable: "LocalUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_LocalUsers_LocalUserId",
                table: "Horses");

            migrationBuilder.DropForeignKey(
                name: "FK_Riders_LocalUsers_LocalUserId",
                table: "Riders");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Riders_LocalUserId",
                table: "Riders");

            migrationBuilder.DropIndex(
                name: "IX_Horses_LocalUserId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "FEIID",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "InsuranceExiprationDate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "LocalUserId",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "MedCheckDate",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "NationalFederationID",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "RidersClubName",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "LocalUsers");

            migrationBuilder.DropColumn(
                name: "DefaultComunicationLanguage",
                table: "LocalUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "LocalUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "LocalUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LocalUsers");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Breeder",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "ChipNumber",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Commets",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "FEIID",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Father",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Heigth",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "LocalUserId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "MedCheckDate",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Mother",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "NatFedID",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "PassportNo",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "PassportNoExipreDate",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "YearOfBird",
                table: "Horses");

            migrationBuilder.RenameColumn(
                name: "RiderID",
                table: "Riders",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerName",
                table: "Horses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BornDate",
                table: "Horses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 1,
                column: "BornDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 2,
                column: "BornDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: 3,
                column: "BornDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
