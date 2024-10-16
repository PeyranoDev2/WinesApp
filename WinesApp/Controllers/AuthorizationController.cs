using Microsoft.AspNetCore.Mvc;
using Services;
using Data.Entities;
using System.Security.Claims;
using System.Text;
using Data.Models;
using System.Net;
using Services.UserServices;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace WinesApp.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthenticationController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(Credentials authenticationRequestBody)
        {

            var user = _userService.AuthenticateUser(authenticationRequestBody);

            if (user is null)
                return Unauthorized();

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);


            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                new Claim("name", user.Username)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Authentication:Issuer"],
                _config["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                credentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}
