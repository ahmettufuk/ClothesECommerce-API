using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;
        private IUserService _userService;

        public AuthsController(IAuthService authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLogin userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            var getClaim = _userService.GetClaims(userToLogin.Data);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            
            if (result.Success)
            {
                return Ok(new{getClaim,result.Data,result.Message});
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegister userForRegister)
        {
            var userExists = _authService.UserExists(userForRegister.Email);
            
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegister, userForRegister.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
