using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.UserDTO;
using CompetitionEventsManager.Repository;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace CompetitionEventsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserRepository userRepository, IUserService userService, IJwtService jwtService, ILogger<UserController> logger)
        {
            _logger = logger;
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
            var userExist =  _userRepository.Exist(model.UserName);
            if (!userExist)
            {
                _logger.LogWarning("Bandoma prisijungti prie sistemos su neegzistuojanciu prisijungimo Vardu ", model.UserName);
                return Unauthorized("Bad username");
            }

            var isOk = _userRepository.TryLogin(model.UserName, model.Password, out var user);
            if (!isOk)
            {
                _logger.LogWarning("Bandoma prisijungti prie Vartotojo {0} su neteisingu slaptazodziu", model.UserName);
                return Unauthorized("Bad password");
            }
               

            var token = _jwtService.GetJwtToken(user.Id, user.Role);


            return Ok(new LoginResponse { UserName = model.UserName, Token = token });
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
                WasOnline = DateTime.UtcNow,
                Adress = model.Adress,
                Phone = model.Phone,
                Email = model.Email,
                Language = model.Language,
            };

            var id = _userRepository.RegisterAsync(user);

            return Created(nameof(Login), new { Id = id });


        }
        //need DScr 



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

