using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ZwajApp.API.Data;
using ZwajApp.API.Dtos;
using ZwajApp.API.Model;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repository, IConfiguration config)
        {
            _config = config;
            _repository = repository;

        }
        [HttpPost("register")]
        public async Task<IActionResult> register(userforregister userDto)
        {

            // if(!ModelState.IsValid){return BadRequest("");}
            //validation 
            userDto.username = userDto.username.ToLower();
            if (await _repository.UserExistes(userDto.username)) return BadRequest("Die User name ist schon Da");
            var createuser = new User { Username = userDto.username };
            var createduser = await _repository.Regsiter(createuser, userDto.password);
            return StatusCode(201);
        }

        [HttpPost("login")]

        public async Task<IActionResult> login(loginDto loginDto)
        {



            var userFromlogin = await _repository.login(loginDto.username.ToLower(), loginDto.password);
            if (userFromlogin == null) return Unauthorized();
            var clams = new[]{
            new Claim(ClaimTypes.NameIdentifier,userFromlogin.Id.ToString()),
             new Claim(ClaimTypes.Name,userFromlogin.Username)

       };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Appsettings:token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(clams),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var Token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(Token) });






        }


    }
}