using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Drawing;
using Microsoft.Extensions.Hosting;

namespace CompetitionEventsManager.Models.Dto.HorseDTO
{
    /// <summary>
    /// DTO
    /// </summary>
    public class GetHorseDTO
    {
        public GetHorseDTO(Horse horse)
        {
            HorseID = horse.HorseID;
            HorseName = horse.HorseName;
            OwnerName = horse.OwnerName;
            YearOfBird = horse.YearOfBird;
            Breed = horse.Breed;
            Type = horse.Type;
            Gender = horse.Gender;
            Color = horse.Color;
            NatFedID = horse.NatFedID;
            FEIID = horse.FEIID;
            Heigth = horse.Heigth;
            Father = horse.Father;
            Mother = horse.Mother;
            Breeder = horse.Breeder;
            Country = horse.Country;
            Commets = horse.Commets;
            MedCheckDate = horse.MedCheckDate;
            PassportNo = horse.PassportNo;
            PassportNoExipreDate = horse.PassportNoExipreDate;
            ChipNumber = horse.ChipNumber;
            UserId = horse.UserId;
        }

        public int HorseID { get; set; }
        public string HorseName { get; set; }
        public string? OwnerName { get; set; }
        public DateTime? YearOfBird { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Breed { get; set; }
        public string? Type { get; set; }
        /// <summary>
        /// without balls is also a gender
        /// </summary>
        public string? Gender { get; set; }
        public string? Color { get; set; }
        public string? NatFedID { get; set; }
        public string? FEIID { get; set; }
        public int? Heigth { get; set; }
        public string? Father { get; set; }
        public string? Mother { get; set; }
        public string? Breeder { get; set; }
        public string? Country { get; set; }
        public string? Commets { get; set; }
        public DateTime? MedCheckDate { get; set; }
        public string? PassportNo { get; set; }
        public DateTime? PassportNoExipreDate { get; set; }
        public string? ChipNumber { get; set; }

        public int? UserId { get; set; }
    }
}
