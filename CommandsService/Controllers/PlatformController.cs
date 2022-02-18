using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        public PlatformController()
        {

        }
        [HttpPost]
        public ActionResult Test()
        {
            Console.WriteLine("smth happened");
            return Ok();
        }
    }
}
