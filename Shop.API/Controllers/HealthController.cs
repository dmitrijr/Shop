using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Controllers
{
    [Authorize(Policy = "adminOnly")]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("viskas ok");
        }
    }
}