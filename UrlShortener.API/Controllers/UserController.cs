using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.DTOs.Users;
using UrlShortener.Application.Interfaces;
using UrlShortener.Infrastructure.Services.JwtTokenService;

namespace UrlShortener.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService, IJwtTokenService _jwtTokenService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthDto authDto)
        {
            var login = authDto.Login;
            var password = authDto.Password;

            await _userService.RegisterUserAsync(login, password);

            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto authDto)
        {
            var user = await _userService.AuthenticateUserAsync(authDto.Login, authDto.Password);
            var token = _jwtTokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
