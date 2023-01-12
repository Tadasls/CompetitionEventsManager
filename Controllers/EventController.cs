using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.EventDTO;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    ///  Event Controler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

     
            private readonly ILogger<EventController> _logger;
            private readonly IEventRepository _eventRepo;
       

            public EventController(ILogger<EventController> logger, IEventRepository repository)
            {
                _logger = logger;
                _eventRepo = repository;
              
            }

            /// <summary>
            /// Fetch Events with a specified ID from DB
            /// </summary>
            /// <param name="id">Requested event ID</param>
            /// <returns>Event by specified ID</returns>
            /// <response code="400">Customer bad request description</response>
            [HttpGet("Event/{id:int}", Name = "GetEvent")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetEventDTO))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Produces(MediaTypeNames.Application.Json)]
            public async Task<ActionResult<GetEventDTO>> GetEventById(int id)
            {
                if (id == 0)
                {
                    _logger.LogInformation("no id imput");
                    return BadRequest("Not entered ID");
                }
                if (!await _eventRepo.ExistAsync(d => d.EventID == id))
                {
                    _logger.LogInformation("Event with id {id} not found", id);
                    return NotFound("No such entries with this ID");
                }
                var eventx = await _eventRepo.GetAsync(d => d.EventID == id);
                return Ok(new GetEventDTO(eventx));
            }

        /// <summary>
        /// Fetches all Events from the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllEvents")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetEventDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEntriesWithFilter([FromQuery] FilterEventRequest req)
        {
            _logger.LogInformation("Getting Horse list with parameters {req}", JsonConvert.SerializeObject(req));
            IEnumerable<Event> entities = await _eventRepo.GetAllAsync();
            if (req.Place != null)
                entities = entities.Where(x => x.Place == req.Place);
            if (req.Country != null)
                entities = entities.Where(x => x.Country == req.Country);
            return Ok(entities
                .Select(d => new GetEventDTO(d))
                .ToList());
        }







        /// <summary>
        /// To delete Event
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("Event/delete/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            if (!await _eventRepo.ExistAsync(d => d.EventID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such ID Entries was found");
            }
            var eventx = await _eventRepo.GetAsync(d => d.EventID == id);
            await _eventRepo.RemoveAsync(eventx);
            return NoContent();
        }






    }
}
