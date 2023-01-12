using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using CompetitionEventsManager.Models.Dto.CompetitionDTO;

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
           

            public CompetitionController(ILogger<CompetitionController> logger, ICompetitionRepository repository)
            {
                _logger = logger;
                _competitionRepo = repository;
             
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

