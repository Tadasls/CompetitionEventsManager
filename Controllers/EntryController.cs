using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace CompetitionEventsManager.Controllers
{
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
        /// Fetches all Entries in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("Entries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Horse>> GetEntries( int Id)
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







    }
}
