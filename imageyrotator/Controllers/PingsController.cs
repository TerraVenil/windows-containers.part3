using Microsoft.AspNetCore.Mvc;

namespace ImageYRotator
{
    [Route("api/pings")]
    public class PingsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() =>
            Ok("Pong");
    }
}