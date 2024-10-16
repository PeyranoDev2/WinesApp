using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.UserServices;

namespace WinesApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserForCreateDTO dto)
        {
            if (dto == null)
                return BadRequest("The body cant be null");
            try
            {
                _userServices.AddUser(dto);
            }
            catch (Exception)
            {
                return BadRequest("This username alredy exists...");
            }
            return Created("Location", "Resource");
        }
    }
}