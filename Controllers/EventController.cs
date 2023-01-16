using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.EventDTO;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Net.Mime;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// EventController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="httpContextAccessor"></param>
        public EventController(ILogger<EventController> logger, IEventRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _eventRepo = repository;
            _httpContextAccessor = httpContextAccessor;
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
        /// Adding new Event into db
        /// </summary>
        /// <param name="eventDTO">New Event data</param>
        /// <returns>CreatedAtRoute with DTO</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("CreateEvent")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateEventDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateEventDTO>> CreateEvent([FromBody] CreateEventDTO eventDTO)
        {
            if (eventDTO == null)
            {
                _logger.LogInformation("Method without data started at: ", DateTime.Now);
                return BadRequest("No data provided");
            }
            Event model = new Event()
            {
           
            Title = eventDTO.Title,
            Place = eventDTO.Place,
            Country = eventDTO.Country,
            Currency = eventDTO.Currency,
            Organizer = eventDTO.Organizer,
            Date = eventDTO.Date,
            Type = eventDTO.Type,
        };
            await _eventRepo.CreateAsync(model);
            return CreatedAtRoute("GetEvent", new { Id = model.EventID }, eventDTO);
        }


        /// <summary>
        /// Event update place 
        /// </summary>
        /// <param name="id">specify which entry to update</param>
        /// <param name="updateEventDTO"> DTo with specific properties</param>
        /// <returns>No content if update is Ok</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Page Not Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("Events/update/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEvent(int id, [FromBody] UpdateEventDTO updateEventDTO)
        {
            if (id == 0 || updateEventDTO == null)
            {
                _logger.LogInformation("No data imputed");
                return BadRequest("No data was provided");
            }
            var foundEvent = await _eventRepo.GetAsync(d => d.EventID == id);
            if (foundEvent == null)
            {
                _logger.LogInformation("Event with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }
            foundEvent.Title = updateEventDTO.Title;
            foundEvent.Place = updateEventDTO.Place;
            foundEvent.Country = updateEventDTO.Country;
            foundEvent.Currency = updateEventDTO.Currency;
            foundEvent.Organizer = updateEventDTO.Organizer;
            foundEvent.Date = updateEventDTO.Date;
            foundEvent.Type = updateEventDTO.Type;
        
         await _eventRepo.UpdateAsync(foundEvent);
            return NoContent();
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
