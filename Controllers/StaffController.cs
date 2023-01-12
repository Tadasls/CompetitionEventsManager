using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mime;
using CompetitionEventsManager.Models.Dto.StaffDTO;
using CompetitionEventsManager.Models;
using Newtonsoft.Json;

namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// Staff Controls
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

            private readonly ILogger<HorseController> _logger;
            private readonly IStaffRepository _staffRepo;
           

            public StaffController(ILogger<HorseController> logger, IStaffRepository repository)
            {
                _logger = logger;
                _staffRepo = repository;
             
            }

            /// <summary>
            /// Fetch registered Staff with a specified ID from DB
            /// </summary>
            /// <param name="id">Requested Staff ID</param>
            /// <returns>Staff by specified ID</returns>
            /// <response code="400">Customer bad request description</response>
            [HttpGet("Staff/{id:int}", Name = "GetStaff")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetStaffDTO))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Produces(MediaTypeNames.Application.Json)]
            public async Task<ActionResult<GetStaffDTO>> GetStaffById(int id)
            {
                if (id == 0)
                {
                    _logger.LogInformation("no id imput");
                    return BadRequest("Not entered ID");
                }
                if (!await _staffRepo.ExistAsync(d => d.StaffID == id))
                {
                    _logger.LogInformation("Horse with id {id} not found", id);
                    return NotFound("No such entries with this ID");
                }
                var horse = await _staffRepo.GetAsync(d => d.StaffID == id);
                return Ok(new GetStaffDTO(horse));
            }

        /// <summary>
        /// Fetches all Staff in the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllStaff")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetStaffDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllStaffWithFilter([FromQuery] FilterStaffRequest req)
        {
            _logger.LogInformation("Getting Staff list with parameters {req}", JsonConvert.SerializeObject(req));
            IEnumerable<Staff> entities = await _staffRepo.GetAllAsync();
                   if (req.Country != null)
                entities = entities.Where(x => x.Country == req.Country);
            return Ok(entities
                .Select(d => new GetStaffDTO(d))
                .ToList());
        }



        /// <summary>
        /// To delete Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        [HttpDelete("Staff/delete/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            if (!await _staffRepo.ExistAsync(d => d.StaffID == id))
            {
                _logger.LogInformation("Staff with id {id} not found", id);
                return NotFound("No such ID Entries was found");
            }
            var staff = await _staffRepo.GetAsync(d => d.StaffID == id);
            await _staffRepo.RemoveAsync(staff);
            return NoContent();
        }













    }
}
