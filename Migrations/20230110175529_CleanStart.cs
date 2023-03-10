using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompetitionEventsManager.Migrations
{
    /// <inheritdoc />
    public partial class CleanStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Place = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Organizer = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WasOnline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    CompetitionType = table.Column<string>(type: "TEXT", nullable: true),
                    ArenaType = table.Column<string>(type: "TEXT", nullable: true),
                    Article = table.Column<string>(type: "TEXT", nullable: true),
                    Phase = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Class = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfJumps = table.Column<int>(type: "INTEGER", nullable: true),
                    NumberOfObstackles = table.Column<int>(type: "INTEGER", nullable: true),
                    TimeAllowed = table.Column<int>(type: "INTEGER", nullable: true),
                    SecToStart = table.Column<int>(type: "INTEGER", nullable: true),
                    PointsForExeedindTimeLimit = table.Column<int>(type: "INTEGER", nullable: true),
                    SheduledStartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SheduledRunTime = table.Column<int>(type: "INTEGER", nullable: true),
                    TimeBeetweenRuns = table.Column<int>(type: "INTEGER", nullable: true),
                    BreakTime = table.Column<int>(type: "INTEGER", nullable: true),
                    AdditionalTime = table.Column<int>(type: "INTEGER", nullable: true),
                    SId = table.Column<int>(type: "INTEGER", nullable: true),
                    EId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionID);
                    table.ForeignKey(
                        name: "FK_Competitions_Events_EId",
                        column: x => x.EId,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    HorseID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HorseName = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfBird = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Breed = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    NatFedID = table.Column<string>(type: "TEXT", nullable: true),
                    FEIID = table.Column<string>(type: "TEXT", nullable: true),
                    Heigth = table.Column<int>(type: "INTEGER", nullable: true),
                    Father = table.Column<string>(type: "TEXT", nullable: true),
                    Mother = table.Column<string>(type: "TEXT", nullable: true),
                    Breeder = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Commets = table.Column<string>(type: "TEXT", nullable: true),
                    MedCheckDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PassportNo = table.Column<string>(type: "TEXT", nullable: true),
                    PassportNoExipreDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ChipNumber = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.HorseID);
                    table.ForeignKey(
                        name: "FK_Horses_LocalUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_LocalUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    RiderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    NationalFederationID = table.Column<int>(type: "INTEGER", nullable: true),
                    FEIID = table.Column<int>(type: "INTEGER", nullable: true),
                    RidersClubName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MedCheckDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    InsuranceExiprationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.RiderID);
                    table.ForeignKey(
                        name: "FK_Riders_LocalUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    FeiID = table.Column<string>(type: "TEXT", nullable: true),
                    NationalID = table.Column<string>(type: "TEXT", nullable: true),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    SId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staffs_Competitions_SId",
                        column: x => x.SId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionID");
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    HorseID = table.Column<int>(type: "INTEGER", nullable: false),
                    RiderID = table.Column<int>(type: "INTEGER", nullable: false),
                    EntryID = table.Column<int>(type: "INTEGER", nullable: false),
                    HorseName = table.Column<string>(type: "TEXT", nullable: true),
                    RiderFullName = table.Column<string>(type: "TEXT", nullable: true),
                    HorseBirthYear = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Points = table.Column<int>(type: "INTEGER", nullable: true),
                    Time = table.Column<double>(type: "REAL", nullable: true),
                    Training = table.Column<bool>(type: "INTEGER", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    NeedElectricity = table.Column<bool>(type: "INTEGER", nullable: true),
                    PlateNumbers = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfCages = table.Column<int>(type: "INTEGER", nullable: true),
                    StayFromDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StayToDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Shavings = table.Column<bool>(type: "INTEGER", nullable: true),
                    NeedInvoice = table.Column<bool>(type: "INTEGER", nullable: true),
                    AgreemntOnContractNr1 = table.Column<bool>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocalUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    CId = table.Column<int>(type: "INTEGER", nullable: true),
                    CompetitionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => new { x.HorseID, x.RiderID });
                    table.ForeignKey(
                        name: "FK_Entries_Competitions_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionID");
                    table.ForeignKey(
                        name: "FK_Entries_Horses_HorseID",
                        column: x => x.HorseID,
                        principalTable: "Horses",
                        principalColumn: "HorseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_LocalUsers_LocalUserId",
                        column: x => x.LocalUserId,
                        principalTable: "LocalUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entries_Riders_RiderID",
                        column: x => x.RiderID,
                        principalTable: "Riders",
                        principalColumn: "RiderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Competitions",
                columns: new[] { "CompetitionID", "AdditionalTime", "ArenaType", "Article", "BreakTime", "Class", "CompetitionType", "Date", "EId", "Number", "NumberOfJumps", "NumberOfObstackles", "Phase", "PointsForExeedindTimeLimit", "SId", "SecToStart", "SheduledRunTime", "SheduledStartTime", "Time", "TimeAllowed", "TimeBeetweenRuns", "Title" },
                values: new object[,]
                {
                    { 1, 5, "Maniezas", "Art.238.2.1 ", 10, "ATVIRA KLASĖ", "lentelė A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), null, "1A. ", 10, 8, 1, 1, null, 45, 2, null, null, null, 2, "Art.238.2.1 Konkūras pagal laiką, lentelė A" },
                    { 2, 5, "Maniezas", "Art.238.2.1 ", 10, "ATVIRA KLASĖ", "lentelė A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), null, "3. ", 10, 8, 1, 1, null, 45, 2, null, null, null, 2, "Art.238.2.1 Konkūras pagal laiką, lentelė A" },
                    { 3, 5, "Maniezas", "Art.238.2.1 ", 10, "ATVIRA KLASĖ", "lentelė A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), null, "5 ", 13, 10, 2, 1, null, 45, 2, null, null, null, 2, "Art.274.2.5 Dviejų fazių konkūras (Lentelė A, pagal laiką abejose fazėse" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "Country", "Currency", "Date", "Organizer", "Place", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "LT", "Eur", null, "Harmony Park", "Vazgaikiemis", "LTU-3* Lietuvos Taurė I etapas", null },
                    { 2, "LT", "Eur", null, "Audruvis", "Joniškio raj.", "LTU-3* Audruvis Equistore 2 nd Birthday Cup ", null },
                    { 3, "LT", "Eur", null, "Dargužiai", "Dargužiai", "CSI1*, CSIOJ, CSICh-A, CSIOCh, CSIP, CSIU25YJ-A", null }
                });

            migrationBuilder.InsertData(
                table: "Horses",
                columns: new[] { "HorseID", "Breed", "Breeder", "ChipNumber", "Color", "Commets", "Country", "FEIID", "Father", "Gender", "Heigth", "HorseName", "MedCheckDate", "Mother", "NatFedID", "OwnerName", "PassportNo", "PassportNoExipreDate", "Type", "UserId", "YearOfBird" },
                values: new object[,]
                {
                    { 1, "Lietuvos sunkusis", null, null, "^irma", null, "LT", null, null, "Kastratas", null, "Kingas", null, null, null, "S. Laurinaitis", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1008) },
                    { 2, "Ristunas", null, null, "Juoda", null, "LT", null, null, "Kastratas", null, "Perkūnas", null, null, null, "S. Laurinaitis", null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1009) },
                    { 3, "KWPN", "E.Onrust", "528003 06.06881", "Širma", null, "Olandija", null, "Silverstone", "Kastratas", null, "Baltasar", null, "Sally", "1700034", "Virginijus Praškevičius", "528003 06.06881", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1972) },
                    { 4, "Zangersheide", null, "528003 06.06881", "Širma", null, "Belgija", null, "CORONAS", "Eržilas", null, "Cassander Z", null, "ANDIENA VH ASDONK ET Z", "1700034", "Valdas Urbonas", "528003 06.06881", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1981) },
                    { 5, "Žemaitukai", "Stasys Svetlauskas", null, "Bėra", null, "Belgija", null, "Koralas", "Kumelė", null, "Kamanė", null, "Kražė", "1700025", "Ernesta Valaitienė", "LTU003210052706", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004) },
                    { 6, "Lietuvos jojamųjų", "Egidijus Civinskas", null, "Juodbėra", null, "Lietuva", null, "Laralee", "Kastratas", null, "Kamanė", null, "Ela", "15444", "Gabrielė Stasiulionytė", "029272", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationID", "Message", "Status", "Topic", "UserId" },
                values: new object[,]
                {
                    { 1, "Prasome atlikti Vet patikra", true, "Vet Patikra", null },
                    { 2, "Prasome atlikti Vet patikra", true, "Vet Patikra", null },
                    { 3, "Prasome atlikti Vet patikra", false, "Vet Patikra", null },
                    { 4, "Prasome patiklinti starto laika", false, "Pakeistas Starto Laikas", null },
                    { 5, "Prasome atlikti Vet patikra", true, "Vet Patikra", null },
                    { 6, "Prasome patiklinti starto laika", false, "Pakeistas Starto Laikas", null },
                    { 7, "Prasome patiklinti starto laika", false, "Pakeistas Starto Laikas", null }
                });

            migrationBuilder.InsertData(
                table: "Riders",
                columns: new[] { "RiderID", "Comments", "Country", "DateOfBirth", "FEIID", "FirstName", "InsuranceExiprationDate", "LastName", "MedCheckDate", "NationalFederationID", "RidersClubName", "UserId" },
                values: new object[,]
                {
                    { 1, null, "LT", null, null, "Andrius", null, "Petrovas", null, null, null, null },
                    { 2, null, "LT", null, null, "Matas", null, "Petraitis", null, null, null, null },
                    { 3, null, "LT", null, null, "Kristupas", null, "Petraitis", null, null, null, null },
                    { 4, null, "LT", null, null, "Nerijus", null, "Šipaila", null, null, null, null },
                    { 5, null, "LT", null, null, "Kostas", null, "Gaigalas", null, null, null, null },
                    { 6, null, "LT", null, null, "Laura", null, "Martinavičiūtė", null, null, null, null },
                    { 7, null, "LT", null, null, "Danielius", null, "Gutkauskas", null, null, null, null },
                    { 8, null, "LT", null, null, "Evita", null, "Vismerytė", null, null, null, null },
                    { 9, null, "LT", null, null, "Karolina ", null, "Vasiliauskaite", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffID", "Country", "FeiID", "FirstName", "Lastname", "NationalID", "Position", "SId" },
                values: new object[,]
                {
                    { 1, "LT", "FEI Level 1", "Marijonas", "Raila", "", "Ground Jury", null },
                    { 2, "LT", "", "Daiva", "Leonavičiūtė", "L3", "Jury", null },
                    { 3, "LT", "", "Ladas", "Katinas", "I NK", "Stuart", null }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "HorseID", "RiderID", "AgreemntOnContractNr1", "CId", "Comments", "CompetitionID", "EntryID", "HorseBirthYear", "HorseName", "LocalUserId", "NeedElectricity", "NeedInvoice", "NumberOfCages", "PlateNumbers", "Points", "RiderFullName", "Shavings", "Status", "StayFromDate", "StayToDate", "Time", "Training", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, null, null, null, 1, null, "The King", null, false, false, 1, "KEK:511", 0, "Linas Balciunas", false, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 0.0, false, null },
                    { 2, 2, false, null, null, null, 2, null, "Perkunas", null, false, true, 2, "KEK:515", 0, "S Laurinaitis", true, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2018), 0.0, false, null },
                    { 3, 3, true, null, null, null, 3, null, "Nabagute", null, true, false, 5, "", 0, "Z Sarka", false, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), 0.0, true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_EId",
                table: "Competitions",
                column: "EId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CompetitionID",
                table: "Entries",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_LocalUserId",
                table: "Entries",
                column: "LocalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_RiderID",
                table: "Entries",
                column: "RiderID");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_UserId",
                table: "Horses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Riders_UserId",
                table: "Riders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_SId",
                table: "Staffs",
                column: "SId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "Riders");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
