using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Controllers
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService tokenService;

        public AuthController(TokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.Username == "user" && loginRequest.Password == "Test1234!")
            {
                var claims = new List<Claim>();

                var response = new
                {
                    AccessToken = tokenService.GenerateAccessToken(claims),
                    RefreshToken = tokenService.GenerateRefreshToken()
                };

                return Ok(response);
            }

            return Unauthorized();
        }
    }
}