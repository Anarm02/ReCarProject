using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin=_authService.Login(userForLoginDto);
            if (!userToLogin.success)
            {
                return BadRequest(userToLogin.message);
            }
            var accessToken = _authService.CreateAccessToken(userToLogin.Data);
            if (!accessToken.success)
            {
                return BadRequest(accessToken.message);
            }
            return Ok(accessToken.Data);
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto) {
        var userExist=_authService.UserExist(userForRegisterDto.Email);
            if (!userExist.success)
            {
                return BadRequest(userExist.message);
            }
            var userToRegister=_authService.Register(userForRegisterDto);
            var accessToken=_authService.CreateAccessToken(userToRegister.Data);
            if (accessToken.success)
            {
                return Ok(accessToken.Data);
            }
            return BadRequest(accessToken.message);
            
        }
    }
}
