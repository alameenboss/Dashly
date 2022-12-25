using Microsoft.AspNetCore.Mvc;

namespace Alameen.Dashly.API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var physicalFileName = @"F:/Birds.mp4";
            return PhysicalFile($"{physicalFileName}", "application/octet-stream", enableRangeProcessing: true);
        }

    }
}
