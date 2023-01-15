using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using CompetitionEventsManager.Models.Dto.CompetitionDTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// Competition Controlers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
     
            private readonly ILogger<CompetitionController> _logger;
            private readonly ICompetitionRepository _competitionRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// competion controler
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="httpContextAccessor"></param>
        public CompetitionController(ILogger<CompetitionController> logger, ICompetitionRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _competitionRepo = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Competition
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Competition/{id:int}", Name = "GetCompetition")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCompetitionDTO))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Produces(MediaTypeNames.Application.Json)]
            public async Task<ActionResult<GetCompetitionDTO>> GetCompetitionById(int id)
            {
                if (id == 0)
                {
                    _logger.LogInformation("no id input");
                    return BadRequest("Not entered ID");
                }
                if (!await _competitionRepo.ExistAsync(d => d.CompetitionID == id))
                {
                    _logger.LogInformation("Competition with id {id} not found", id);
                    return NotFound("No such entries with this ID");
                }
                var competition = await _competitionRepo.GetAsync(d => d.CompetitionID == id);
                return Ok(new GetCompetitionDTO(competition));
            }

        /// <summary>
        /// Fetches all Competitions from the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllCompetitions")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCompetitionDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCompetitionsWithFilter([FromQuery] FilterCompetitionRequest req)
        {
            _logger.LogInformation("Getting Competition list with parameters {req}", JsonConvert.SerializeObject(req));
            IEnumerable<Competition> entities = await _competitionRepo.GetAllAsync();
            if (req.Article != null)
                entities = entities.Where(x => x.Article == req.Article);
            if (req.Class != null)
                entities = entities.Where(x => x.Class == req.Class);
       
            return Ok(entities
                .Select(d => new GetCompetitionDTO(d))
                .ToList());
        }


        /// <summary>
        /// Adding new Competition into db
        /// </summary>
        /// <param name="competitionDTO">New horse data</param>
        /// <returns>CreatedAtRoute with DTO</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("CreateCompetition")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCompetitionDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateCompetitionDTO>> CreateCompetition([FromBody] CreateCompetitionDTO competitionDTO)
        {
            if (competitionDTO == null)
            {
                _logger.LogInformation("Method without data started at: ", DateTime.Now);
                return BadRequest("No data provided");
            }

            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId == null)
            {
                return Forbid();
            }

            Competition model = new Competition()
            {
            Title = competitionDTO.Title,
            Number = competitionDTO.Number,
            CompetitionType = competitionDTO.CompetitionType,
            ArenaType = competitionDTO.ArenaType,
            Article = competitionDTO.Article,
            Phase = competitionDTO.Phase,
            Date = competitionDTO.Date,
            Time = competitionDTO.Time,
            Class = competitionDTO.Class,
            NumberOfJumps = competitionDTO.NumberOfJumps,
            NumberOfObstackles = competitionDTO.NumberOfObstackles,
            TimeAllowed = competitionDTO.TimeAllowed,
            SecToStart = competitionDTO.SecToStart,
            PointsForExeedindTimeLimit = competitionDTO.PointsForExeedindTimeLimit,
            SheduledStartTime = competitionDTO.SheduledStartTime,
            SheduledRunTime = competitionDTO.SheduledRunTime,
            TimeBeetweenRuns = competitionDTO.TimeBeetweenRuns,
            BreakTime = competitionDTO.BreakTime,
            AdditionalTime = competitionDTO.AdditionalTime,
            //SId = competitionDTO.SId,
            EId = competitionDTO.EId,
            };
            await _competitionRepo.CreateAsync(model);
            return CreatedAtRoute("GetCompetition", new { Id = model.CompetitionID }, competitionDTO);
        }





        /// <summary>
        /// Competition update place 
        /// </summary>
        /// <param name="id">specify which entry to update</param>
        /// <param name="updateCompetitionDTO"> DTo with specific properties</param>
        /// <returns>No content if update is Ok</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Page Not Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("Competitions/update/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateCompetition( int id, [FromBody] UpdateCompetitionDTO updateCompetitionDTO)
        {
            if (id == 0 || updateCompetitionDTO == null)
            {
                _logger.LogInformation("no data imputed");
                return BadRequest("No data was provided");
            }

            var foundCompetition = await _competitionRepo.GetAsync(d => d.CompetitionID == id);
            if (foundCompetition == null)
            {
                _logger.LogInformation("Competition with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }

            foundCompetition.Title = updateCompetitionDTO.Title;
            foundCompetition.Number = updateCompetitionDTO.Number;
            foundCompetition.CompetitionType = updateCompetitionDTO.CompetitionType;
            foundCompetition.ArenaType = updateCompetitionDTO.ArenaType;
            foundCompetition.Article = updateCompetitionDTO.Article;
            foundCompetition.Phase = updateCompetitionDTO.Phase;
            foundCompetition.Date = updateCompetitionDTO.Date;
            foundCompetition.Time = updateCompetitionDTO.Time;
            foundCompetition.Class = updateCompetitionDTO.Class;
            foundCompetition.NumberOfJumps = updateCompetitionDTO.NumberOfJumps;
            foundCompetition.NumberOfObstackles = updateCompetitionDTO.NumberOfObstackles;
            foundCompetition.TimeAllowed = updateCompetitionDTO.TimeAllowed;
            foundCompetition.SecToStart = updateCompetitionDTO.SecToStart;
            foundCompetition.PointsForExeedindTimeLimit = updateCompetitionDTO.PointsForExeedindTimeLimit;
            foundCompetition.SheduledStartTime = updateCompetitionDTO.SheduledStartTime;
            foundCompetition.SheduledRunTime = updateCompetitionDTO.SheduledRunTime;
            foundCompetition.TimeBeetweenRuns = updateCompetitionDTO.TimeBeetweenRuns;
            foundCompetition.BreakTime = updateCompetitionDTO.BreakTime;
            foundCompetition.AdditionalTime = updateCompetitionDTO.AdditionalTime;
           // foundCompetition.SId = updateCompetitionDTO.SId;
            foundCompetition.EId = updateCompetitionDTO.EId;

            await _competitionRepo.UpdateAsync(foundCompetition);
            return NoContent();
        }














        /// <summary>
        /// To delete Competition
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("Competition/delete/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCompetition(int id)
        {
            if (!await _competitionRepo.ExistAsync(d => d.CompetitionID == id))
            {
                _logger.LogInformation("Competition with id {id} not found", id);
                return NotFound("No such ID Entries was found");
            }
            var competition = await _competitionRepo.GetAsync(d => d.CompetitionID == id);
            await _competitionRepo.RemoveAsync(competition);
            return NoContent();
        }



    }

}

