using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net.Mime;
using System.Reflection;

namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// Žirgų kontroleris
    /// </summary>
    
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
        [Authorize]
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
        public async Task<IActionResult> GetAllHorsesWithFilter([FromQuery] FilterHorsesRequest req)
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



        /// <summary>
        /// Irasomas Žirgas i duomenu baze
        /// </summary>
        /// <returns></returns>
        /// <response code="400">paduodamos informacijos validacijos klaidos </response>
        [HttpPost("Horser")]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateHorseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateHorseDTO>> CreateHorse(CreateHorseDTO horseDTO)
        {
            if (horseDTO == null)
            {
                _logger.LogInformation("Metodas be duomenų sukurimui buvo iškviestas tokiu laiku  ",  DateTime.Now);
                return BadRequest("Duomenys neužpildyti");
            }

            Horse model = new Horse()
            {
            HorseName = horseDTO.HorseName,
            OwnerName = horseDTO.OwnerName,
            YearOfBird = horseDTO.YearOfBird,
            Breed = horseDTO.Breed,
            Type = horseDTO.Type,
            Gender = horseDTO.Gender,
            Color = horseDTO.Color,
            NatFedID = horseDTO.NatFedID,
            FEIID = horseDTO.FEIID,
            Heigth = horseDTO.Heigth,
            Father = horseDTO.Father,
            Mother = horseDTO.Mother,
            Breeder = horseDTO.Breeder,
            Country = horseDTO.Country,
            Commets = horseDTO.Commets,
            MedCheckDate = horseDTO.MedCheckDate,
            PassportNo = horseDTO.PassportNo,
            PassportNoExipreDate = horseDTO.PassportNoExipreDate,
            ChipNumber = horseDTO.ChipNumber
             };

            await _horseRepo.CreateAsync(model);

            return CreatedAtRoute("GetHorse", new { Id = model.HorseID }, horseDTO);
        }









        /// <summary>
        /// Trinamas Žirgas is duomenu bazes
        /// </summary>
        /// <returns></returns>
        [HttpDelete("horses/delete/{id:int}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteHorse(int id)
        {
            if (!await _horseRepo.ExistAsync(d => d.HorseID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("Nerasta įrašų pagal įvestą ID");
            }
            var horse = await _horseRepo.GetAsync(d => d.HorseID == id);
            await _horseRepo.RemoveAsync(horse);
            return NoContent();
        }















    }
}
