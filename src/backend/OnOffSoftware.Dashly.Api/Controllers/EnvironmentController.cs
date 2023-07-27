using OnOffSoftware.Dashly.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace OnOffSoftware.Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly AppSettings appSettings;

        public EnvironmentController(IOptions<AppSettings> options)
        {
            this.appSettings = options.Value;
        }

        [HttpGet]
        public async Task<string> GetAsync()
        {
            return await Task.FromResult(appSettings.Environment);
        }
    }
}
