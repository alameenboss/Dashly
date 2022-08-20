using AutoMapper;
using Dashly.API.Feature.DataImport;
using Dashly.API.Feature.WebApps.Data.Entity;
using Dashly.API.Feature.WebApps.Data.Repository;
using Dashly.API.Feature.WebApps.DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dashly.API.Feature.WebApps
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebappController : ControllerBase
    {
        private readonly IWebappRepository _webappRepository;
        private readonly IMapper _mapper;
        private readonly IDataImport<Webapp> _dataImport;

        public WebappController(IWebappRepository webappRepository, 
            IDataImport<Webapp> dataImport,
            IMapper mapper)
        {
            _webappRepository = webappRepository;
            _mapper = mapper;
            _dataImport = dataImport;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Webapp>>> GetAll()
        {
            var entities = await _webappRepository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Webapp>> GetById(int id)
        {
            var entity = await _webappRepository.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(CreateWebappRequest request)
        {
            var entity = _mapper.Map<Webapp>(request);
            await _webappRepository.Insert(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Webapp>> Update(UpdateWebappRequest request, int id)
        {
            var entity = _mapper.Map<Webapp>(request);
            await _webappRepository.Update(entity, id);
            return Ok(entity);
        }

        [HttpPost("{id}/addatachment")]
        public async Task<ActionResult<Webapp>> AddAttachment(int id, AttachmentRequest request)
        {
            var attachment = _mapper.Map<Attachment>(request);
            await _webappRepository.AddAttachment(id, attachment);
            return Ok(attachment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _webappRepository.Delete(id);
            return Ok(new { success = "Success" });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await _webappRepository.DeleteAll();
            return Ok(new { success = "Success" });
        }

        [HttpPut("import"), DisableRequestSizeLimit]
        public async Task Import(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string data = Encoding.UTF8.GetString(fileBytes);
                var webapps = await _dataImport.ExecuteAsync(data);
                await _webappRepository.Import(webapps);
            }
        }
    }
}