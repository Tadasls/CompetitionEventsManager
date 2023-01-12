using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.RiderDTO;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mime;
using System.Xml.Linq;


namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// This way to Riders Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RiderController : ControllerBase
    {

       
            private readonly ILogger<RiderController> _logger;
            private readonly IRiderRepository _riderRepo;
            private readonly IRiderAdapter _riderAdapter;
           

            public RiderController(ILogger<RiderController> logger, IRiderRepository repository, IRiderAdapter riderAdapter)
            {
                _logger = logger;
                _riderRepo = repository;
                _riderAdapter = riderAdapter;
            }

            /// <summary>
            /// Fetch registered rider with a specified ID from DB
            /// </summary>
            /// <param name="id">Requested rider ID</param>
            /// <returns>rider by specified ID</returns>
            /// <response code="400">Customer bad request description</response>
            [HttpGet("Riders/{id:int}", Name = "GetRider")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRiderDTO))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Produces(MediaTypeNames.Application.Json)]
            public async Task<ActionResult<GetRiderDTO>> GetriderById(int id)
            {
                if (id == 0)
                {
                    _logger.LogInformation("no id imput");
                    return BadRequest("Not entered ID");
                }
                if (!await _riderRepo.ExistAsync(d => d.RiderID == id))
                {
                    _logger.LogInformation("Rider with id {id} not found", id);
                    return NotFound("No such entries with this ID");
                }
                var rider = await _riderRepo.GetAsync(d => d.RiderID == id);
                return Ok(new GetRiderDTO(rider));
            }

            /// <summary>
            /// Fetches all registered riders in the DB
            /// </summary>
            /// <param name="req"></param>
            /// <returns>All Entities</returns>
            [HttpGet("GetAllRiders")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetRiderDTO>))]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<IActionResult> GetAllRidersWithFilter([FromQuery] FilterRidersRequest req)
            {
                IEnumerable<Rider> entities = await _riderRepo.GetAllAsync();
                if (req.FirstName != null)
                    entities = entities.Where(x => x.FirstName == req.FirstName);
                if (req.LastName != null)
                    entities = entities.Where(x => x.LastName == req.LastName);
                if (req.RidersClubName != null)
                    entities = entities.Where(x => x.RidersClubName == req.RidersClubName);
                if (req.Country != null)
                    entities = entities.Where(x => x.Country == req.Country);
                return Ok(entities
                    .Select(d => new GetRiderDTO(d))
                    .ToList());
            }

            /// <summary>
            /// Adding new rider into db
            /// </summary>
            /// <param name="riderDTO">New rider data</param>
            /// <returns>CreatedAtRoute with DTO</returns>
            [HttpPost("CreateRider")]
            //[Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateRiderDTO))]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [Produces(MediaTypeNames.Application.Json)]
            public async Task<ActionResult<CreateRiderDTO>> CreateRider([FromBody] CreateRiderDTO riderDTO)
            {
                if (riderDTO == null)
                {
                    _logger.LogInformation("Method without data started at: ", DateTime.Now);
                    return BadRequest("No data provided");
                }
                Rider model = new Rider()
                {
                FirstName = riderDTO.FirstName,
                LastName = riderDTO.LastName,
                NationalFederationID = riderDTO.NationalFederationID,
                FEIID = riderDTO.FEIID,
                RidersClubName = riderDTO.RidersClubName,
                DateOfBirth = riderDTO.DateOfBirth,
                MedCheckDate = riderDTO.MedCheckDate,
                InsuranceExiprationDate = riderDTO.InsuranceExiprationDate,
                Country = riderDTO.Country,
                Comments = riderDTO.Comments,
                  };

                await _riderRepo.CreateAsync(model);
                return CreatedAtRoute("GetRider", new { Id = model.RiderID }, riderDTO);
            }

            /// <summary>
            /// rider update place 
            /// </summary>
            /// <param name="id">specify which entry to update</param>
            /// <param name="updateriderDTO"> DTo with specific properties</param>
            /// <returns>No content if update is Ok</returns>
            [HttpPut("riders/update/{id:int}")]
            // [Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> Updaterider([FromQuery] int id, [FromBody] UpdateRiderDTO updateRiderDTO)
            {
                if (id == 0 || updateRiderDTO == null)
                {
                    _logger.LogInformation("no data imputed");
                    return BadRequest("No data was provided");
                }

                var foundRider = await _riderRepo.GetAsync(d => d.RiderID == id);
                if (foundRider == null)
                {
                    _logger.LogInformation("rider with id {id} not found", id);
                    return NotFound("No such entries with this ID");
                }

            foundRider.FirstName = updateRiderDTO.FirstName;
            foundRider.FirstName = updateRiderDTO.FirstName;
            foundRider.LastName = updateRiderDTO.LastName;
            foundRider.NationalFederationID = updateRiderDTO.NationalFederationID;
            foundRider.FEIID = updateRiderDTO.FEIID;
            foundRider.RidersClubName = updateRiderDTO.RidersClubName;
            foundRider.DateOfBirth = updateRiderDTO.DateOfBirth;
            foundRider.MedCheckDate = updateRiderDTO.MedCheckDate;
            foundRider.InsuranceExiprationDate = updateRiderDTO.InsuranceExiprationDate;
            foundRider.Country = updateRiderDTO.Country;
            foundRider.Comments = updateRiderDTO.Comments;

                await _riderRepo.UpdateAsync(foundRider);
                return NoContent();
            }


            /// <summary>
            /// UpdatePartialrider with Patch
            /// </summary>
            /// <param name="id"></param>
            /// <param name="request"></param>
            /// <returns>No content</returns>
            [HttpPatch("patch/{id:int}", Name = "UpdatePartialrider")]
            // [Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> UpdatePartialRider([FromQuery] int id, [FromBody] JsonPatchDocument<Rider> request)
            {
                if (id == 0 || request == null)
                {
                    _logger.LogInformation("Method without data started at: ", DateTime.Now);
                    return BadRequest("No data provided for update");
                }
                var riderExists = await _riderRepo.ExistAsync(d => d.RiderID == id);
                if (!riderExists)
                {
                    _logger.LogInformation("rider with id {id} not found", id);
                    return NotFound("No such rider with ID was found");
                }
                var foundRider = await _riderRepo.GetAsync(d => d.RiderID == id);
                request.ApplyTo(foundRider, ModelState);
                await _riderRepo.UpdateAsync(foundRider);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return NoContent();
            }

            /// <summary>
            ///  Update with Patch with DTO
            /// </summary>
            /// <param name="id">rider Id</param>
            /// <param name="request"> dto data for update</param>
            /// <returns>No Content</returns>
            [HttpPatch("patch/{id:int}/dto", Name = "UpdatePartialriderDto")]
            // [Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> UpdatePartialriderByDto([FromQuery] int id, [FromBody] JsonPatchDocument<UpdateRiderDTO> request)
            {
                if (id == 0 || request == null)
                {
                    _logger.LogInformation("Method without data started at: ", DateTime.Now);
                    return BadRequest("No data provided for update");
                }
                var riderExists = await _riderRepo.ExistAsync(d => d.RiderID == id);
                if (!riderExists)
                {
                    _logger.LogInformation("Rider with id {id} not found", id);
                    return NotFound("No such Rider with ID was found");
                }
                var foundRider = await _riderRepo.GetAsync(d => d.RiderID == id, tracked: false);
                var updateRiderDto = _riderAdapter.Bind(foundRider);
                request.ApplyTo(updateRiderDto, ModelState);
                var rider = _riderAdapter.Bind(updateRiderDto, foundRider.RiderID);
                await _riderRepo.UpdateAsync(rider);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return NoContent();
            }

            /// <summary>
            /// To delete rider
            /// </summary>
            /// <param name="id"></param>
            /// <returns>No Content</returns>
            [HttpDelete("riders/delete/{id:int}")]
           // [Authorize(Roles = "admin,user")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult> Deleterider( int id)
            {
                if (!await _riderRepo.ExistAsync(d => d.RiderID == id))
                {
                    _logger.LogInformation("Rider with id {id} not found", id);
                    return NotFound("No such ID Entries was found");
                }
                var rider = await _riderRepo.GetAsync(d => d.RiderID == id);
                await _riderRepo.RemoveAsync(rider);
                return NoContent();
            }





    }

}

