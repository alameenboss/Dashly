using AutoMapper;
using Dashly.API.DataImport;
using Dashly.API.Feature.Contacts.Models;
using Dashly.API.Models.Contacts.Request;
using Dashly.API.Repositories.Data.Entity;
using Dashly.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        private readonly IDataImport _dataImport;

        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _dataImport = new ImportContact(_contactRepository);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            var entities = await _contactRepository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetById(int id)
        {
            var entity = await _contactRepository.GetById(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(CreateContactRequest request)
        {
            var entity = _mapper.Map<Contact>(request);
            await _contactRepository.Insert(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> Update(UpdateContactRequest request, int id)
        {
            var entity = _mapper.Map<Contact>(request);
            await _contactRepository.Update(entity, id);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _contactRepository.Delete(id);
            return Ok(new { success = "Success" });
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await _contactRepository.DeleteAll();
            return Ok(new { success = "Success" });
        }

        [HttpPut("import"), DisableRequestSizeLimit]
        public async Task<bool> Import(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string data = Encoding.UTF8.GetString(fileBytes);
                await _dataImport.ExecuteAsync(data);
            }

            return true;
        }
    }
}