using Common.Exceptions;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.WineServices;
using System;

namespace WinesApp.Controllers
{
    [Route("api/wine")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {
        public readonly IWineService _wineService;
        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet]
        public IActionResult GetAllWines()
        {
            var wines = _wineService.Get();
            return Ok(wines);
        }

        [HttpGet("{id}")]
        public ActionResult<WineForResponseDTO> GetWineById(int id)
        {
            try
            {
                var wineResponse = _wineService.Get(id);
                return Ok(wineResponse); 
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message); 
            }
        }

        [HttpPost]
        public IActionResult AddWine([FromBody] WineForCreateDTO wineDTO)
        {
            try
            {
                var wineId = _wineService.AddWine(wineDTO);
                return CreatedAtAction(nameof(GetWineById), new { id = wineId }, wineId);
            }
            catch (InvalidWineVarietyException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (InvalidWineRegionException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (WineAlreadyExistsException exception)
            {
                return Conflict(exception.Message); 
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message); 
            }
        }

        [HttpGet] 
        [Route("/stock")] 
        public IActionResult GetAllWinesStock()
        {
            return Ok(_wineService.GetAllWinesStock());
        }

        [HttpPut("update-stock/{wineId}")]
        public IActionResult UpdateStock(int wineId, [FromBody] int newStock)
        {
            try
            {
                _wineService.UpdateWineStock(wineId, newStock);
                return NoContent(); 
            }
            catch (KeyNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message); 
            }
        }

        [HttpGet("variety/{variety}")]
        public IActionResult GetWinesByVariety(string variety)
        {
            try
            {
                var wines = _wineService.GetWinesByVariety(variety);
                return Ok(wines); 
            }
            catch (InvalidWineVarietyException exception)
            {
                return BadRequest(exception.Message); 
            }
        }
    }
}
