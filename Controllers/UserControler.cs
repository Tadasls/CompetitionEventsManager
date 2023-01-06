using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.IServices;
using Microsoft.AspNetCore.Mvc;


namespace CompetitionEventsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserRepository userRepository, IUserService userService, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _userService = userService;
            _jwtService = jwtService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var isOk = _userRepository.TryLogin(model.Username, model.Password, out var user);
            if (!isOk)
                return Unauthorized("Bad username or password");

            var token = _jwtService.GetJwtToken(user.Id, user.Role);


            return Ok(new LoginResponse { UserName = model.Username, Token = token });
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest model)
        {
            if (_userRepository.Exist(model.UserName))
                return BadRequest("User already exists");

            _userService.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);
            var user = new LocalUser
            {
                Username = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RegistrationDate = DateTime.UtcNow,
                WasOnline = DateTime.UtcNow
            };

            var id = _userRepository.RegisterAsync(user);

            return Created(nameof(Login), new { id = id });
        }


        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<GetUserDto>> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest("nera tokio ID");
            }
            var user = await _userRepository.GetAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound("nera tokio vartotojo");
            }

            return Ok(user);
        }





    }




}

