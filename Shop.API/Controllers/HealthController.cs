using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Controllers
{
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