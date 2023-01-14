﻿using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Newtonsoft.Json;
using System.Net.Mime;
using CompetitionEventsManager.Models.Dto.EntryDTO;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using CompetitionEventsManager.Models.Dto.RiderDTO;

namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// This is Entries controls
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {

        private readonly ILogger<HorseController> _logger;
        private readonly IEntryRepository _entryRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EntryController(ILogger<HorseController> logger, IEntryRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _entryRepo = repository;
            _httpContextAccessor = new HttpContextAccessor();
        }


        /// <summary>
        /// To get All Entries by User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/GetAllEntriesForUser/{id:int}", Name = "GetAllEntries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetEntryDTO>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetEntryDTO>> GetUsersEntriesByUserId(int id)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != id)
            {
                _logger.LogWarning("User {currentUserId} tried to access users {id} Entries", currentUserId, id);
                return Forbid("No access");
            }

            var userEnties = await _entryRepo.GetAllFewDBAsync(x => x.UserId == id, new List<string>() { "LocalUser" });
            if (userEnties == null) return NotFound("User does not have Entries");


            return Ok(userEnties
             .Select(userEnties => new GetEntryDTO(userEnties))
             .ToList());
        }


        /// <summary>
        /// Fetch registered Entries with a specified ID from DB
        /// </summary>
        /// <param name="id">Requested Entry ID</param>
        /// <returns>Entry by specified ID</returns>
        /// <response code="400">Customer bad request description</response>
        [HttpGet("Entries/{id:int}", Name = "GetEntry")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEntryDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<GetEntryDTO>> GetHorseById(int id)
        {
            if (id == 0)
            {
                _logger.LogInformation("No id input");
                return BadRequest("Not entered ID");
            }
     

            if (!await _entryRepo.ExistAsync(d => d.HorseID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }
            var horse = await _entryRepo.GetAsync(d => d.HorseID == id);

            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != horse.UserId)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {id} horses", currentUserId, id);
                return Forbid("No access");
            }

            return Ok(new GetEntryDTO(horse));
        }

        /// <summary>
        /// Fetches all registered Entries in the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllEntries")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetEntryDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEntriesWithFilter([FromQuery] FilterEntriesRequest req)
        {
            _logger.LogInformation("Getting Horse list with parameters {req}", JsonConvert.SerializeObject(req));
            IEnumerable<Entry> entities = await _entryRepo.GetAllAsync();
            if (req.EntryID != null)
                entities = entities.Where(x => x.EntryID == req.EntryID);
            if (req.HorseID != null)
                entities = entities.Where(x => x.HorseID == req.HorseID);
            if (req.RiderID != null)
                entities = entities.Where(x => x.RiderID == req.RiderID);

            return Ok(entities
                .Select(d => new GetEntryDTO(d))
                .ToList());
        }


        /// <summary>
        /// Adding new Entry into db
        /// </summary>
        /// <param name="entryDTO">New Entry data</param>
        /// <returns>CreatedAtRoute with DTO</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("CreateEntry")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateEntryDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateEntryDTO>> CreateEntry([FromBody] CreateEntryDTO entryDTO)
        {
            if (entryDTO == null)
            {
                _logger.LogInformation("Method without data started at: ", DateTime.Now);
                return BadRequest("No data provided");
            }
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId == null)
            {
                return Forbid("No access");
            }

            Entry model = new Entry()
            {
            HorseID = entryDTO.HorseID,
            RiderID = entryDTO.RiderID,
            HorseName = entryDTO.HorseName,
            RiderFullName = entryDTO.RiderFullName,
            HorseBirthYear = entryDTO.HorseBirthYear,
            Points = entryDTO.Points,
            Time = entryDTO.Time,
            Training = entryDTO.Training,
            Status = entryDTO.Status,
            Comments = entryDTO.Comments,
            NeedElectricity = entryDTO.NeedElectricity,
            PlateNumbers = entryDTO.PlateNumbers,
            NumberOfCages = entryDTO.NumberOfCages,
            StayFromDate = entryDTO.StayFromDate,
            StayToDate = entryDTO.StayToDate,
            Shavings = entryDTO.Shavings,
            NeedInvoice = entryDTO.NeedInvoice,
            AgreemntOnContractNr1 = entryDTO.AgreemntOnContractNr1,
            UserId = currentUserId,
            CId = entryDTO.CId,
        };
            await _entryRepo.CreateAsync(model);
            return CreatedAtRoute("GetEntry", new { Id = model.EntryID }, entryDTO);
      

        }


        /// <summary>
        /// Entry update place 
        /// </summary>
        /// <param name="id">specify which entry to update</param>
        /// <param name="updateEntryDTO"> DTo with specific properties</param>
        /// <returns>No content if update is Ok</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Page Not Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("Entrys/update/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEntry( int id, [FromBody] UpdateEntryDTO updateEntryDTO)
        {
            if (id == 0 || updateEntryDTO == null)
            {
                _logger.LogInformation("no data imputed");
                return BadRequest("No data was provided");
            }

            var foundEntry = await _entryRepo.GetAsync(d => d.EntryID == id);
            if (foundEntry == null)
            {
                _logger.LogInformation("Entry with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != foundEntry.UserId)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {id} horses", currentUserId, id);
                return Forbid("No access");
            }


            foundEntry.HorseName = updateEntryDTO.HorseName;
            foundEntry.RiderFullName = updateEntryDTO.RiderFullName;
            foundEntry.HorseBirthYear = updateEntryDTO.HorseBirthYear;
            foundEntry.Points = updateEntryDTO.Points;
            foundEntry.Time = updateEntryDTO.Time;
            foundEntry.Training = updateEntryDTO.Training;
            foundEntry.Status = updateEntryDTO.Status;
            foundEntry.Comments = updateEntryDTO.Comments;
            foundEntry.NeedElectricity = updateEntryDTO.NeedElectricity;
            foundEntry.PlateNumbers = updateEntryDTO.PlateNumbers;
            foundEntry.NumberOfCages = updateEntryDTO.NumberOfCages;
            foundEntry.StayFromDate = updateEntryDTO.StayFromDate;
            foundEntry.StayToDate = updateEntryDTO.StayToDate;
            foundEntry.Shavings = updateEntryDTO.Shavings;
            foundEntry.NeedInvoice = updateEntryDTO.NeedInvoice;
            foundEntry.AgreemntOnContractNr1 = updateEntryDTO.AgreemntOnContractNr1;
            foundEntry.UserId = currentUserId;
            foundEntry.CId = updateEntryDTO.CId;

    await _entryRepo.UpdateAsync(foundEntry);
            return NoContent();
        }

        /// <summary>
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("Entries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Horse>> GetEntries(int Id)
        {
            var data = _entryRepo.GetSomeWithSQL(Id);

            return Ok(data); // grazina zirgo objekta pagal ID
        }


        /// <summary>
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("EntriesEager")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Horse>> GetEntriesEager(int Id)
        {

            var data = _entryRepo.Getdata_With_EagerLoading(Id);

            return Ok(data); //grazino visus entries su visais competitions /id cia nieko nedaro
        }

        /// <summary>
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("EntriesEager2")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Horse>> GetEntriesEager2(int Id)
        {

            var data = _entryRepo.Getdata_With_EagerLoading2(Id);

            return Ok(data); // graziai grazino visus eventus su visais competitionais
        }

        /// <summary>
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("EntriesEager3")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Entry>> GetEntriesEager3(int Id)
        {

            var data = _entryRepo.Getdata_With_EagerLoading3(Id);

            return Ok(data); // graziai grazino visus eventus su visais competitionais
        }

        /// <summary>
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("HorsesFromEntries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Entry>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Entry>> GetUserHorseByEntryId(int id)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != id)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {id} horses", currentUserId, id);
                return Forbid("No access");
            }

            var entryHorses = await _entryRepo.GetFewDBAsync(x => x.UserId == id, new List<string> { "Horse" });

            return Ok(entryHorses);//grazino entry klasu su zirgo klase 

        }

        
        /// <summary>
        /// To delete Entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("Entry/delete/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteEntryHorse(int id)
        {
            if (!await _entryRepo.ExistAsync(d => d.EntryID == id))
            {
                _logger.LogInformation("Entry with id {id} not found", id);
                return NotFound("No such ID Entries was found");
            }
            var entry = await _entryRepo.GetAsync(d => d.EntryID == id);

            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != entry.UserId)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {id} Entries", currentUserId, id);
                return Forbid("No access");
            }


            await _entryRepo.RemoveAsync(entry);
            return NoContent();
        }





    }
}
