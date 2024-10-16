using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.WineServices;

namespace WinesApp.Controllers
{
    [Route("api/wine")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {
        public readonly IWineService _wineServices;
        public WineController(IWineService wineServices)
        {
            _wineServices = wineServices;
        }

        [HttpPost]
        public IActionResult AddWine([FromBody] WineForCreateDTO wineDTO)
        {
            if (wineDTO == null)
                return BadRequest("The body request is null");
            {
                int newWineId = (_wineServices.AddWine(wineDTO));
                return Ok(newWineId);
            }
        }

        [HttpGet]
        public IActionResult GetAllWinesStock()
        {
            return Ok(_wineServices.GetAllWinesStock());
        }
    }
}