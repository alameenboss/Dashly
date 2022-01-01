using Dashly.API.Data.Entity;
using Dashly.API.Feature.Notes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dashly.API.Feature.DataImport
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDataController : Controller
    {
        private DashlyContext _context;

        public ImportDataController(DashlyContext context)
        {
            _context = context;
        }

        [HttpPut("{type}"), DisableRequestSizeLimit]
        public async Task<bool> Upload(string type, IFormFile file)
        {
            var dataImpoter = new Dictionary<string, IDataImport>();
            dataImpoter.Add("notes", new ImportNote(_context));
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string data = Encoding.UTF8.GetString(fileBytes);
                await dataImpoter[type].ExecuteAsync(data);
            }

            return true;
        }
    }
}