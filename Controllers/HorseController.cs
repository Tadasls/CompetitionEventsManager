﻿using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Repository.IRepository;
using CompetitionEventsManager.Services.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;


namespace CompetitionEventsManager.Controllers
{
    /// <summary>
    /// Horse Controlers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly ILogger<HorseController> _logger;
        private readonly IHorseRepository _horseRepo;
        private readonly IHorseAdapter _horseAdapter;
        /// <summary>
        /// this is Horse Controlller
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repository"></param>
        /// <param name="horseAdapter"></param>
        public HorseController(ILogger<HorseController> logger, IHorseRepository repository, IHorseAdapter horseAdapter)
        {
            _logger = logger;
            _horseRepo = repository;
            _horseAdapter = horseAdapter;
        }

        /// <summary>
        /// Fetch registered horse with a specified ID from DB
        /// </summary>
        /// <param name="id">Requested Horse ID</param>
        /// <returns>Horse by specified ID</returns>
        /// <response code="400">Customer bad request description</response>
        [HttpGet("Horses/{id:int}", Name = "GetHorse")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetHorseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<GetHorseDTO>> GetHorseById(int id)
        {       
            if (id == 0)
            {
                _logger.LogInformation("no id input");
                return BadRequest("Not entered ID");
            }         
            if (!await _horseRepo.ExistAsync(d => d.HorseID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }
            var horse = await _horseRepo.GetAsync(d => d.HorseID == id);
            return Ok(new GetHorseDTO(horse));
        }

        /// <summary>
        /// Fetches all registered Horses in the DB
        /// </summary>
        /// <param name="req"></param>
        /// <returns>All Entities</returns>
        [HttpGet("GetAllHorses")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetHorseDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllHorsesWithFilter([FromQuery] FilterHorsesRequest req)
        {
            _logger.LogInformation("Getting Horse list with parameters {req}", JsonConvert.SerializeObject(req));
            IEnumerable<Horse> entities = await _horseRepo.GetAllAsync();
            if (req.HorseName != null)
                entities = entities.Where(x => x.HorseName == req.HorseName);
            if (req.OwnerName != null)
                entities = entities.Where(x => x.OwnerName == req.OwnerName);
            if (req.Breeder != null)
                entities = entities.Where(x => x.Breeder == req.Breeder);
            if (req.Country != null)
                entities = entities.Where(x => x.Country == req.Country);
            return Ok(entities
                .Select(d => new GetHorseDTO(d))
                .ToList());
        }



        /// <summary>
        /// Adding new Horse into db
        /// </summary>
        /// <param name="horseDTO">New horse data</param>
        /// <returns>CreatedAtRoute with DTO</returns>
        [HttpPost("CreateHorse")]
        //[Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateHorseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<CreateHorseDTO>> CreateHorse([FromBody] CreateHorseDTO horseDTO)
        {
            if (horseDTO == null)
            {
                _logger.LogInformation("Method without data started at: ",  DateTime.Now);
                return BadRequest("No data provided");
            }
            Horse model = new Horse()
            {
            HorseName = horseDTO.HorseName,
            OwnerName = horseDTO.OwnerName,
            YearOfBird = horseDTO.YearOfBird,
            Breed = horseDTO.Breed,
            Type = horseDTO.Type,
            Gender = horseDTO.Gender,
            Color = horseDTO.Color,
            NatFedID = horseDTO.NatFedID,
            FEIID = horseDTO.FEIID,
            Heigth = horseDTO.Heigth,
            Father = horseDTO.Father,
            Mother = horseDTO.Mother,
            Breeder = horseDTO.Breeder,
            Country = horseDTO.Country,
            Commets = horseDTO.Commets,
            MedCheckDate = horseDTO.MedCheckDate,
            PassportNo = horseDTO.PassportNo,
            PassportNoExipreDate = horseDTO.PassportNoExipreDate,
            ChipNumber = horseDTO.ChipNumber
             };
            await _horseRepo.CreateAsync(model);
            return CreatedAtRoute("GetHorse", new { Id = model.HorseID }, horseDTO);
        }

        /// <summary>
        /// Horse update place 
        /// </summary>
        /// <param name="id">specify which entry to update</param>
        /// <param name="updateHorseDTO"> DTo with specific properties</param>
        /// <returns>No content if update is Ok</returns>
        [HttpPut("Horses/update/{id:int}")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateHorse([FromQuery] int id, [FromBody] UpdateHorseDTO updateHorseDTO)
        {
            if (id == 0 || updateHorseDTO == null)
            {
                _logger.LogInformation("no data imputed");
                return BadRequest("No data was provided");
            }

            var foundHorse = await _horseRepo.GetAsync(d => d.HorseID == id);
            if (foundHorse == null)
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such entries with this ID");
            }
          
            foundHorse.HorseName = updateHorseDTO.HorseName;
            foundHorse.OwnerName = updateHorseDTO.OwnerName;
            foundHorse.YearOfBird = updateHorseDTO.YearOfBird;
            foundHorse.Breed = updateHorseDTO.Breed;
            foundHorse.Type = updateHorseDTO.Type;
            foundHorse.Gender = updateHorseDTO.Gender;
            foundHorse.Color = updateHorseDTO.Color;
            foundHorse.NatFedID = updateHorseDTO.NatFedID;
            foundHorse.FEIID = updateHorseDTO.FEIID;
            foundHorse.Heigth = updateHorseDTO.Heigth;
            foundHorse.Father = updateHorseDTO.Father;
            foundHorse.Mother = updateHorseDTO.Mother;
            foundHorse.Breeder = updateHorseDTO.Breeder;
            foundHorse.Country = updateHorseDTO.Country;
            foundHorse.Commets = updateHorseDTO.Commets;
            foundHorse.MedCheckDate = updateHorseDTO.MedCheckDate;
            foundHorse.PassportNo = updateHorseDTO.PassportNo;
            foundHorse.PassportNoExipreDate = updateHorseDTO.PassportNoExipreDate;
            foundHorse.ChipNumber = updateHorseDTO.ChipNumber;

            await _horseRepo.UpdateAsync(foundHorse);
            return NoContent();
        }


        /// <summary>
        /// UpdatePartialHorse with Patch
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>No content</returns>
        [HttpPatch("Patch/{id:int}", Name = "UpdatePartialHorse")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePartialHorse([FromQuery] int id, [FromBody] JsonPatchDocument<Horse> request)
        {
            if (id == 0 || request == null)
            {
                _logger.LogInformation("Method without data started at: ", DateTime.Now);
                return BadRequest("No data provided for update");
            }
            var horseExists = await _horseRepo.ExistAsync(d => d.HorseID == id);
            if (!horseExists)
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such Horse with ID was found");
            }
            var foundHorse = await _horseRepo.GetAsync(d => d.HorseID == id);
            request.ApplyTo(foundHorse, ModelState);
            await _horseRepo.UpdateAsync(foundHorse);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        /// <summary>
        ///  Update with Patch with DTO
        /// </summary>
        /// <param name="id">Horse Id</param>
        /// <param name="request"> dto data for update</param>
        /// <returns>No Content</returns>
        [HttpPatch("Patch/{id:int}/dto", Name = "UpdatePartialHorseDto")]
        // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePartialHorseByDto([FromQuery] int id, [FromBody] JsonPatchDocument<UpdateHorseDTO> request)
        {
            if (id == 0 || request == null)
            {
                _logger.LogInformation("Method without data started at: ", DateTime.Now);
                return BadRequest("No data provided for update");
            }
            var horseExists = await _horseRepo.ExistAsync(d => d.HorseID == id);
            if (!horseExists)
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such Horse with ID was found");
            }
            var foundHorse = await _horseRepo.GetAsync(d => d.HorseID == id, tracked: false);
            var updateHorseDto = _horseAdapter.Bind(foundHorse);
            request.ApplyTo(updateHorseDto, ModelState);
            var horse = _horseAdapter.Bind(updateHorseDto, foundHorse.HorseID);
            await _horseRepo.UpdateAsync(horse);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

       /// <summary>
       /// To delete Horse
       /// </summary>
       /// <param name="id"></param>
       /// <returns>No Content</returns>
        [HttpDelete("Horses/delete/{id:int}")]
       // [Authorize(Roles = "admin,user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteHorse( int id)
        {
            if (!await _horseRepo.ExistAsync(d => d.HorseID == id))
            {
                _logger.LogInformation("Horse with id {id} not found", id);
                return NotFound("No such ID Entries was found");
            }
            var horse = await _horseRepo.GetAsync(d => d.HorseID == id);
            await _horseRepo.RemoveAsync(horse);
            return NoContent();
        }






    }
}
