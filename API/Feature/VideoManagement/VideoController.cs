using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dashly.API.Feature.VideoManagement
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
