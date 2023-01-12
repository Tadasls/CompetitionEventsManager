using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Services.Adapters;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace CompetitionEventsManager.Data.InitialData
{
    public static class HorseInitialData
    {

        public static readonly Rider [] RidersDataSeed = new Rider[] {
                new Rider
                {
                    RiderID = 1,
                    FirstName = "Andrius",
                    LastName = "Petrovas",
                   
                },
                 new Rider
                {
                    RiderID = 2,
                    FirstName = "Matas",
                    LastName = "Petraitis",
                 
                },
                   new Rider
                {
                    RiderID = 3,
                    FirstName = "Kristupas",
                    LastName = "Petraitis",
                  
                },
                    new Rider
                {
                    RiderID = 4,
                    FirstName = "Nerijus",
                    LastName = "Šipaila",
                    
                },
                new Rider
                {
                    RiderID = 5,
                    FirstName = "Kostas",
                    LastName = "Gaigalas",
                
                },
                   new Rider
                {
                    RiderID = 6,
                    FirstName = "Laura",
                    LastName = "Martinavičiūtė",
                  
                },
                new Rider
                {
                    RiderID = 7,
                    FirstName = "Danielius",
                    LastName = "Gutkauskas",
                  
                },
                   new Rider
                {
                    RiderID = 8,
                    FirstName = "Evita",
                    LastName = "Vismerytė",
                 
                },
                  new Rider
                {
                    RiderID = 9,
                    FirstName = "Karolina ",
                    LastName = "Vasiliauskaite",
               
                },





               };

        public static readonly Horse[] HorseDataSeed = new Horse[] {
                new Horse
                {
                    HorseID = 1,
                    HorseName = "Kingas",
                    OwnerName = "S. Laurinaitis",
                    YearOfBird = new DateTime(2017/02/01),
                       Breed  = "Lietuvos sunkusis",
                    Gender =  "Kastratas",
                    Color  = "^irma",
                    Country =  "LT",

                },
                     new Horse
                {
                    HorseID = 2,
                    HorseName = "Perkūnas",
                    OwnerName = "S. Laurinaitis",
                    YearOfBird = new DateTime(2019/02/01),
                    Breed  = "Ristunas",
                    Gender =  "Kastratas",
                    Color  = "Juoda",
                    Country =  "LT",
                 
                },
               new Horse
                {
                    HorseID = 3,
                    HorseName = "Baltasar",
                    OwnerName = "Virginijus Praškevičius",
                    YearOfBird = new DateTime(2006-05-29),
                    Breed = "KWPN",
                   Gender = "Kastratas",
                   Color = "Širma",
                   NatFedID = "1700034",
                   Father  = "Silverstone",
                   Mother = "Sally",
                   Breeder =  "E.Onrust",
                   Country =  "Olandija",
                   PassportNo = "528003 06.06881",
                   ChipNumber = "528003 06.06881",

                },
                    new Horse
                {
                    HorseID = 4,
                    HorseName = "Cassander Z",
                    OwnerName = "Valdas Urbonas",
                    YearOfBird = new DateTime(2009-05-23),
                    Breed = "Zangersheide",
                   Gender = "Eržilas",
                   Color = "Širma",
                   NatFedID = "1700034",
                   Father  = "CORONAS",
                   Mother = "ANDIENA VH ASDONK ET Z",
                   Country =  "Belgija",
                   PassportNo = "528003 06.06881",
                   ChipNumber = "528003 06.06881",

                },
                new Horse
                {
                    HorseID = 5,
                    HorseName = "Kamanė",
                    OwnerName = "Ernesta Valaitienė",
                    YearOfBird = new DateTime(2006-01-01),
                    Breed = "Žemaitukai",
                   Gender = "Kumelė",
                   Color = "Bėra",
                   NatFedID = "1700025",
                   Father  = "Koralas",
                   Mother = "Kražė",
                   Country =  "Belgija",
                   PassportNo = "LTU003210052706",
                   Breeder =  "Stasys Svetlauskas",
                },
                   new Horse
                {
                    HorseID = 6,
                    HorseName = "Kamanė",
                    OwnerName = "Gabrielė Stasiulionytė",
                    YearOfBird = new DateTime(2010-03-20),
                    Breed = "Lietuvos jojamųjų",
                   Gender = "Kastratas",
                   Color = "Juodbėra",
                   NatFedID = "15444",
                   Father  = "Laralee",
                   Mother = "Ela",
                   Country =  "Lietuva",
                   PassportNo = "029272",
                   Breeder =  "Egidijus Civinskas",

                },



               };

        public static readonly Competition[] CompetitionDataSeed = new Competition[] {
                new Competition
                {
                    CompetitionID = 1,
                    Title = "Art.238.2.1 Konkūras pagal laiką, lentelė A",
                    Number = "1A. ",
                    CompetitionType = "lentelė A",
                    ArenaType = "Maniezas",
                    Article = "Art.238.2.1 ",
                    Phase = 1,
                    Date= new DateTime(2023-03-03),
                    Class = "ATVIRA KLASĖ",
                    NumberOfJumps= 10,
                    NumberOfObstackles = 8,
                    SecToStart = 45,
                    PointsForExeedindTimeLimit = 1,
                    TimeBeetweenRuns = 2,
                    BreakTime = 10,
                    AdditionalTime = 5,
                 
                },
                   new Competition
                {
                    CompetitionID = 2,
                    Title = "Art.238.2.1 Konkūras pagal laiką, lentelė A",
                    Number = "3. ",
                    CompetitionType = "lentelė A",
                    ArenaType = "Maniezas",
                    Article = "Art.238.2.1 ",
                    Phase = 1,
                    Date= new DateTime(2023-03-03),
                    Class = "ATVIRA KLASĖ",
                    NumberOfJumps= 10,
                    NumberOfObstackles = 8,
                    SecToStart = 45,
                    PointsForExeedindTimeLimit = 1,
                    TimeBeetweenRuns = 2,
                    BreakTime = 10,
                    AdditionalTime = 5,
                 
                },
                      new Competition
                {
                    CompetitionID = 3,
                    Title = "Art.274.2.5 Dviejų fazių konkūras (Lentelė A, pagal laiką abejose fazėse",
                    Number = "5 ",
                    CompetitionType = "lentelė A",
                    ArenaType = "Maniezas",
                    Article = "Art.238.2.1 ",
                    Phase = 2,
                    Date= new DateTime(2023-03-03),
                    Class = "ATVIRA KLASĖ",
                    NumberOfJumps= 13,
                    NumberOfObstackles = 10,
                    SecToStart = 45,
                    PointsForExeedindTimeLimit = 1,
                    TimeBeetweenRuns = 2,
                    BreakTime = 10,
                    AdditionalTime = 5,
                  
                },

               };

        public static readonly Entry[] EntryDataSeed = new Entry[] {
             new Entry
                {
                    EntryID = 1,
                    HorseID = 1,
                    RiderID = 1,
                    HorseName = "The King",
                    RiderFullName = "Linas Balciunas",
                    Training = false,
                    Status = "Confirmed",
                    NeedElectricity  = false,
                    PlateNumbers = "KEK:511",
                    NumberOfCages  = 1,
                    StayFromDate = new DateTime(2024-01-01),
                    StayToDate = new DateTime(2024-01-05),
                    Shavings  = false,
                    NeedInvoice = false,
                    AgreemntOnContractNr1 = true,

                },
             new Entry
                {
                    EntryID = 2,
                    HorseID = 2,
                    RiderID = 2,
                    HorseName = "Perkunas",
                    RiderFullName = "S Laurinaitis",
                    Training = false,
                    Status = "Confirmed",
                    NeedElectricity  = false,
                    PlateNumbers = "KEK:515",
                    NumberOfCages  = 2,
                    StayFromDate = new DateTime(2024-01-01),
                    StayToDate = new DateTime(2024-01-05),
                    Shavings  = true,
                    NeedInvoice = true,
                    AgreemntOnContractNr1 = false,

                },
             new Entry
                {
                    EntryID = 3,
                    HorseID = 3,
                    RiderID = 3,
                    HorseName = "Nabagute",
                    RiderFullName = "Z Sarka",
                    Training = true,
                    Status = "Confirmed",
                    NeedElectricity  = true,
                    PlateNumbers = "",
                    NumberOfCages  = 5,
                    StayFromDate = new DateTime(2024-02-01),
                    StayToDate = new DateTime(2024-02-05),
                    Shavings  = false,
                    NeedInvoice = false,
                    AgreemntOnContractNr1 = true,

                }

               };

        public static readonly Event[] EventDataSeed = new Event[] {
                new Event
                {
                    EventID = 1,
                    Title = "LTU-3* Lietuvos Taurė I etapas",
                    Place = "Vazgaikiemis",
                    Country = "LT",
                    Currency = "Eur",
                    Organizer = "Harmony Park",
                },
                 new Event
                {
                    EventID = 2,
                    Title = "LTU-3* Audruvis Equistore 2 nd Birthday Cup ",
                    Place = "Joniškio raj.",
                    Country = "LT",
                    Currency = "Eur",
                    Organizer = "Audruvis",
                },
                   new Event
                {
                    EventID = 3,
                    Title = "CSI1*, CSIOJ, CSICh-A, CSIOCh, CSIP, CSIU25YJ-A",
                    Place = "Dargužiai",
                    Country = "LT",
                    Currency = "Eur",
                    Organizer = "Dargužiai",
                }
               };

        public static readonly Notification[] NotificationDataSeed = new Notification[] {
            new Notification    
            {
                    NotificationID = 1,
                    Topic =  "Vet Patikra",
                    Message = "Prasome atlikti Vet patikra",
                    Status =  true, 
             },
             new Notification
            {
                NotificationID = 2,
                Topic = "Vet Patikra",
                Message = "Prasome atlikti Vet patikra",
                Status = true,
              
            },
               new Notification
            {
              NotificationID = 3,
                Topic = "Vet Patikra",
                Message = "Prasome atlikti Vet patikra",
                Status = false,
              
            },
               new Notification
            {
               NotificationID = 4,
               Topic = "Pakeistas Starto Laikas",
                Message = "Prasome patiklinti starto laika",
                Status = false,
              
            },
                new Notification
            {
              NotificationID = 5,
                Topic = "Vet Patikra",
                Message = "Prasome atlikti Vet patikra",
                Status = true,
              
            },
                 new Notification
            {
              NotificationID = 6,
                Topic = "Pakeistas Starto Laikas",
                Message = "Prasome patiklinti starto laika",
                Status = false,
              
            },
                 new Notification
            {
              NotificationID = 7,
                Topic = "Pakeistas Starto Laikas",
                Message = "Prasome patiklinti starto laika",
                Status = false,
           
            },
           };

        public static readonly Staff[] StaffDataSeed = new Staff[] {
                new Staff
                {
                    StaffID = 1,
                    FirstName = "Marijonas",
                    Lastname = "Raila",
                    Country = "LT",
                    FeiID = "FEI Level 1",
                    NationalID = "",
                    Position = "Ground Jury",
                },
                 new Staff
                {
                  StaffID = 2,
                    FirstName = "Daiva",
                    Lastname = "Leonavičiūtė",
                    Country = "LT",
                    FeiID = "",
                    NationalID = "L3",
                    Position = "Jury",
                },
                   new Staff
                {
                    StaffID = 3,
                    FirstName = "Ladas",
                    Lastname = "Katinas",
                    Country = "LT",
                    FeiID = "",
                    NationalID = "I NK",
                    Position = "Stuart",
                }
               };



        //    public static readonly LocalUser[] LocalUsersDataSeed = new LocalUser[] {


        //              string kodas = "TlSlTZjKsczePNRBc7x2bW9cNQX7hZo8PNCwQsZDsAY";
        //              byte[] bytes = Encoding.ASCII.GetBytes(kodas);


        //    new LocalUser
        //        {

        //            Id = 1,
        //            UserName = "Tadas",
        //            FirstName = "Tadas",
        //            LastName = "Laurinaitis",
        //            PasswordHash = TlSlTZjKsczePNRBc7x2bW9cNQX7hZo8PNCwQsZDsAY=,
        //            PasswordSalt = puT7gLDRAGQRvzKOT0I8aCA6ujCCdxh7ipfY/6NIyvEGV0TWz46PFNde/GPH1gIXJD7KBQa2a6BXLkxpPSB9CQ==,
        //            Role = "admin",
        //            RegistrationDate = DateTime.Now,
        //            WasOnline = DateTime.Now,
        //            Adress = "Kaunas",
        //            Phone = "860012345",
        //            Language = "Lt",

        //        },


        //};






    }
    }