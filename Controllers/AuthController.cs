using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ObaOba.API.Dtos;
using ObaOba.API.Models;
using ObaOba.API.Services;

namespace ObaOba.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto user) 
        {
            try 
            {

                if (await _authService.EmailExists(user.Email))
                    ModelState.AddModelError("Email", "Email already exists");
                
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var entity = new User(
                    user.Name,
                    user.LastName,
                    user.Email.ToLower(),
                    DateTime.Now
                );

                await _authService.Register(entity, user.Password);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto user)
        {
            try
            {
                var result = await _authService.Login(user.Email.ToLower(), user.Password);   

                if (result == null)
                    return Unauthorized();

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
                        new Claim(ClaimTypes.Email, result.Email)
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var tokenCreatead = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenCreatead);

                return Ok(new { token });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}