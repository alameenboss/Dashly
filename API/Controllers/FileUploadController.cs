using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public FileUploadController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<string>>> Upload()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Images");
                var pathToSave = Path.Combine(Configuration["AppConfig:FilesStoragePath"], folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                var result = new List<string>();
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    result.Add(dbPath);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                return result ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
