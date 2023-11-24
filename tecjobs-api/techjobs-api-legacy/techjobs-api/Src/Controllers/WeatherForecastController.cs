using Microsoft.AspNetCore.Mvc;

namespace techjobs_api.Src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<String> Get()
        {
            return Ok("Hello World!");
        }
    }
}
