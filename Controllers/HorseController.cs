using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CompetitionEventsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly ILogger<HorseController> _logger;
        private readonly IHorseRepository _horseRepo;
   
        public HorseController(ILogger<HorseController> logger, IHorseRepository repository)
        {
            _logger = logger;
            _horseRepo = repository;
           
        }

               

        /// <summary>
        /// Fetch registered horse with a specified ID from DB
        /// </summary>
        /// <param name="id">Requested Horse ID</param>
        /// <returns>Horse with specified ID</returns>
        /// <response code="400">Customer bad request description</response>
        [HttpGet("horses/{id:int}", Name = "GetHorse")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetHorseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
       // [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<GetHorseDTO>> GetHorseById(int id)
        {       
            if (id == 0)
            {
                return BadRequest("Neivestas ID");
            }         

            if (!await _horseRepo.ExistAsync(d => d.HorseID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("Nerasta įrašų pagal įvestą ID");
            }
            var horse = await _horseRepo.GetAsync(d => d.HorseID == id);

            return Ok(new GetHorseDTO(horse));
        }


        

        /// <summary>
        /// Fetches all registered Horses in the DB
        /// </summary>
        /// <returns>All Horses in DB</returns>
        [HttpGet("Horses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHorses([FromQuery] FilterHorsesRequest req)
        {
            IEnumerable<Horse> entities = await _horseRepo.GetAllAsync();

            if (req.HorseName != null)
                entities = entities.Where(x => x.HorseName == req.HorseName);

            if (req.OwnerName != null)
                entities = entities.Where(x => x.OwnerName == req.OwnerName);

            if (req.Breeder != null)
                entities = entities.Where(x => x.Breeder == req.Breeder);

            if (req.Country != null)
                entities = entities.Where(x => x.Country == req.Country);

                      
            return Ok(entities
                .Select(d => new GetHorseDTO(d))
                .ToList());
        }










    }
}
