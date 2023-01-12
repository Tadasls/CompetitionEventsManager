using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Newtonsoft.Json;
using System.Net.Mime;
using CompetitionEventsManager.Models.Dto.EntryDTO;

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

        public EntryController(ILogger<HorseController> logger, IEntryRepository repository)
        {
            _logger = logger;
            _entryRepo = repository;
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
                _logger.LogInformation("no id input");
                return BadRequest("Not entered ID");
            }
            //_httpContextAccessor !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (!await _entryRepo.ExistAsync(d => d.HorseID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }
            var horse = await _entryRepo.GetAsync(d => d.HorseID == id);
            return Ok(new GetEntryDTO(horse));
        }

        /// <summary>
        /// Fetches all registered Entries in the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllEentries")]
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

            var entryHorses = await _entryRepo.GetFewDBAsync(x => x.UserId == id, new List<string> { "Horse" });

            return Ok(entryHorses);//grazino entry klasu su zirgo klase 

        }


        /// <summary>
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("HorsesFromEntriesAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Entry>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Entry>> GetUserHorsesByEntryId(int id)
        {

            var entryHorses = await _entryRepo.GetAllFewDBAsync(x => x.UserId == id, new List<string> { "Horse" });

            return Ok(entryHorses); //grazino entry klasu su zirgo klase 

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
            await _entryRepo.RemoveAsync(entry);
            return NoContent();
        }









    }
}
