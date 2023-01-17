using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Models.Dto.NotificationDTO;
using Microsoft.AspNetCore.Authorization;

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
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// that makes noti control to be
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="httpContextAccessor"></param>
        public NotificationController(ILogger<NotificationController> logger, INotificationRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _notiRepo = repository;
            _httpContextAccessor = httpContextAccessor;
        }


       /// <summary>
       /// Notifications get All
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("/GetAllNotificationsForUser/{id:int}", Name = "GetAllNotifications")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetNotificationDTO>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetNotificationDTO>> GetUsersNotificationsByUserId(int id)
        {
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != id)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {id} notifications", currentUserId, id);
                return Forbid();
            }

            var userNotifications = await _notiRepo.GetAllFewDBAsync(x => x.UserId == id, new List<string>() { "LocalUser" });
            if (userNotifications == null) return NotFound("User does not have an Notifications");


            return Ok(userNotifications
             .Select(userNotifications => new GetNotificationDTO(userNotifications))
             .ToList());
        }












        /// <summary>
        /// Fetch all Notifications specified ID from DB
        /// </summary>
        /// <param name="id">Requested Notification ID</param>
        /// <returns>Notification by specified ID</returns>
        /// <response code="400">Customer bad request description</response>
        [HttpGet("Notification/{id:int}", Name = "GetNotification")]
            [Authorize(Roles = "admin,user")]
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
        [Authorize(Roles = "admin,user")]
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
        /// Adding new Notification into db
        /// </summary>
        /// <param name="NotificationDTO">New Notification data</param>
        /// <returns>CreatedAtRoute with DTO</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("CreateNotification")]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateNotificationDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateNotificationDTO>> CreateNotification([FromBody] CreateNotificationDTO notificationDTO)
        {
            if (notificationDTO == null)
            {
                _logger.LogInformation("Method without data started at: ", DateTime.Now);
                return BadRequest("No data provided");
            }
            Notification model = new Notification()
            {
          
            Topic = notificationDTO.Topic,
            Message = notificationDTO.Message,
            Status = notificationDTO.Status,
            UserId = notificationDTO.UserId,
        };
            await _notiRepo.CreateAsync(model);
            return CreatedAtRoute("GetNotification", new { Id = model.NotificationID }, notificationDTO);
        }








        /// <summary>
        /// Notification update place 
        /// </summary>
        /// <param name="id">specify which entry to update</param>
        /// <param name="updateNotificationDTO"> DTo with specific properties</param>
        /// <returns>No content if update is Ok</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Page Not Found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("Notifications/update/{id:int}")]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateNotification( int id, [FromBody] UpdateNotificationDTO updateNotificationDTO)
        {
            if (id == 0 || updateNotificationDTO == null)
            {
                _logger.LogInformation("no data imputed");
                return BadRequest("No data was provided");
            }

            var foundNotification = await _notiRepo.GetAsync(d => d.NotificationID == id);
            if (foundNotification == null)
            {
                _logger.LogInformation("Notification with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }

            foundNotification.Topic = updateNotificationDTO.Topic;
            foundNotification.Message = updateNotificationDTO.Message;
            foundNotification.Status = updateNotificationDTO.Status;
            foundNotification.UserId = updateNotificationDTO.UserId;

            await _notiRepo.UpdateAsync(foundNotification);
            return NoContent();
        }















        /// <summary>
        /// To delete Notification
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("Notification/delete/{id:int}")]
        [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != notification.UserId)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {id} Notifications", currentUserId, id);
                return Forbid();
            }

            await _notiRepo.RemoveAsync(notification);
            return NoContent();
        }







    }
}
