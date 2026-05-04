using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Services;

namespace Shop.API.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService tokenService;
        private readonly IUserService userService;

        public AuthController(TokenService tokenService, IUserService userService)
        {
            this.tokenService = tokenService;
            this.userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = userService.Login(loginRequest.Username, loginRequest.Password);
            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("user", "true")
            };

            var response = new
            {
                AccessToken = tokenService.GenerateAccessToken(claims),
                RefreshToken = tokenService.GenerateRefreshToken()
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                var id = userService.Register(registerRequest.Username, registerRequest.Password);
                return Ok(new { Id = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(username))
                return Unauthorized();

            var success = userService.ChangePassword(username, changePasswordRequest.CurrentPassword, changePasswordRequest.NewPassword);
            if (!success)
                return BadRequest("Unable to change password.");

            return NoContent();
        }
    }
}
