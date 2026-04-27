using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Blogas oras");
        }
    }
}