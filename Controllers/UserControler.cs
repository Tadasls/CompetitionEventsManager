using CompetitionEventsManager.Models.Dto;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace CompetitionEventsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;

        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ActionResult))]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var loginResponse = await _userRepo.LoginAsync(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(loginResponse);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest model)
        {
            var isUserNameUnique = await _userRepo.IsUniqueUserAsync(model.Username);

            if (!isUserNameUnique)
            {
                return BadRequest(new { message = "Username already exists" });
            }

            var user = await _userRepo.RegisterAsync(model);

            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }

            return Ok();
        }
        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<GetUserDto>> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest("nera tokio ID");
            }
            var user = await _userRepo.GetAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound("nera tokio vartotojo");
            }

            return Ok(user);
        }








    }
}
