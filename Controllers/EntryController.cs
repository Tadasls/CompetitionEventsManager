using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CompetitionEventsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntryController : ControllerBase
    {
       
      
        private readonly IEntryRepository _entryRepo;
       
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<EntryController> _logger;
        public EntryController(IEntryRepository repository, ILogger<EntryController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _entryRepo = repository;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
      
        }

        [HttpGet("/api/user/{key}/Entries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Entry>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get(int key)
        {
            // var id = _httpContextAccessor.HttpContext.Request.Query["personId"];
            var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (currentUserId != key)
            {
                _logger.LogWarning("User {currentUserId} tried to access user {key} entries", currentUserId, key);
                return Forbid();
            }
            var entry = await _entryRepo.GetAsync(d => d.EntryID == key); 

            return Ok(entry);
            
        }















    }
}
