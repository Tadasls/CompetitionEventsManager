using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Horse>> GetEntries( int req)
        {
           // var kazkas = _entryRepo.GetSome(req);
            var kazkas = _entryRepo.Getdata_With_EagerLoading(req);



            return Ok(kazkas);
        }








    }
}
