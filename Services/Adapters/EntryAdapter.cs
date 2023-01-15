using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.RiderDTO;
using CompetitionEventsManager.Models.Dto.EntryDTO;
using System.Security.Cryptography;
using System.Xml.Linq;
using CompetitionEventsManager.Services.Adapters.IAdapters;

namespace CompetitionEventsManager.Services.Adapters
{
    public class EntryAdapter : IEntryAdapter
    {
        public UpdateEntryDTO Bind(Entry entry)
        {
            return new UpdateEntryDTO
            {
         
            //HorseID = entry.HorseID,
            //RiderID = entry.RiderID,
            HorseName = entry.HorseName,
            RiderFullName = entry.RiderFullName,
            HorseBirthYear = entry.HorseBirthYear,
            Points = entry.Points,
            Time = entry.Time,
            Training = entry.Training,
            Status = entry.Status,
            Comments = entry.Comments,
            NeedElectricity = entry.NeedElectricity,
            PlateNumbers = entry.PlateNumbers,
            NumberOfCages = entry.NumberOfCages,
            StayFromDate = entry.StayFromDate,
            StayToDate = entry.StayToDate,
            Shavings = entry.Shavings,
            NeedInvoice = entry.NeedInvoice,
            AgreemntOnContractNr1 = entry.AgreemntOnContractNr1,
            CId = entry.CId,
        };
        }

        public Entry Bind(UpdateEntryDTO updateEntryDTO, int id)
        {
            return new Entry
            {
        EntryID = id,
        //HorseID = updateEntryDTO.HorseID,
        //RiderID = updateEntryDTO.RiderID,
        HorseName = updateEntryDTO.HorseName,
        RiderFullName = updateEntryDTO.RiderFullName,
        HorseBirthYear = updateEntryDTO.HorseBirthYear,
        Points = updateEntryDTO.Points,
        Time = updateEntryDTO.Time,
        Training = updateEntryDTO.Training,
        Status = updateEntryDTO.Status,
        Comments = updateEntryDTO.Comments,
        NeedElectricity = updateEntryDTO.NeedElectricity,
        PlateNumbers = updateEntryDTO.PlateNumbers,
        NumberOfCages = updateEntryDTO.NumberOfCages,
        StayFromDate = updateEntryDTO.StayFromDate,
        StayToDate = updateEntryDTO.StayToDate,
        Shavings = updateEntryDTO.Shavings,
        NeedInvoice = updateEntryDTO.NeedInvoice,
        AgreemntOnContractNr1 = updateEntryDTO.AgreemntOnContractNr1,
        CId = updateEntryDTO.CId,
    };
        }



    









    }
}
