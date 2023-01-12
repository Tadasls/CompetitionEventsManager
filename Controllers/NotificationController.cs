using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Models.Dto.NotificationDTO;

namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// This is Notifications controls
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
      
            private readonly ILogger<NotificationController> _logger;
            private readonly INotificationRepository _notiRepo;
          

            public NotificationController(ILogger<NotificationController> logger, INotificationRepository repository)
            {
                _logger = logger;
                _notiRepo = repository;
              
            }

            /// <summary>
            /// Fetch all Notifications specified ID from DB
            /// </summary>
            /// <param name="id">Requested Notification ID</param>
            /// <returns>Notification by specified ID</returns>
            /// <response code="400">Customer bad request description</response>
            [HttpGet("Notification/{id:int}", Name = "GetNotification")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetNotificationDTO))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Produces(MediaTypeNames.Application.Json)]
            public async Task<ActionResult<GetNotificationDTO>> GetNotificationById(int id)
            {
                if (id == 0)
                {
                    _logger.LogInformation("no id input");
                    return BadRequest("Not entered ID");
                }
                if (!await _notiRepo.ExistAsync(d => d.NotificationID == id))
                {
                    _logger.LogInformation("Notification with id {id} not found", id);
                    return NotFound("No such entries with this ID");
                }
                var notification = await _notiRepo.GetAsync(d => d.NotificationID == id);
                return Ok(new GetNotificationDTO(notification));
            }

        /// <summary>
        /// Fetches all Notifications in the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllNotifications")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetNotificationDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllHorsesWithFilter([FromQuery] FilterNotificationRequest req)
        {
            _logger.LogInformation("Getting Notification list with parameters {req}", JsonConvert.SerializeObject(req));
            IEnumerable<Notification> entities = await _notiRepo.GetAllAsync();
            if (req.Topic != null)
                entities = entities.Where(x => x.Topic == req.Topic);
    

            return Ok(entities
                .Select(d => new GetNotificationDTO(d))
                .ToList());
        }













        /// <summary>
        /// To delete Notification
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("Notification/delete/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteNotification(int id)
        {
            if (!await _notiRepo.ExistAsync(d => d.NotificationID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such ID Entries was found");
            }
            var notification = await _notiRepo.GetAsync(d => d.NotificationID == id);
            await _notiRepo.RemoveAsync(notification);
            return NoContent();
        }







    }
}
