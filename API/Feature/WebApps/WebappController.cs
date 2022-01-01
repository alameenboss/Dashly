using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dashly.API.Models.Webapps.Request;
using Dashly.API.Repositories.Data.Entity;
using Dashly.API.Repositories.Interface;

namespace Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebappController : ControllerBase
    {
        private readonly IWebappRepository _webappRepository;
        private readonly IMapper _mapper;

        public WebappController(IWebappRepository webappRepository, IMapper mapper)
        {
            _webappRepository = webappRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<Webapp>> AddAttachment(int id,AttachmentRequest request)
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
    }
}