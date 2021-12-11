using AutoMapper;
using Dashly.API.Feature.Documents.Data;
using Dashly.API.Feature.Documents.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Documents
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _documentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Document> GetById(string id)
        {
            return await _documentRepository.GetById(id);
        }

        [HttpPost]
        public async Task<bool> Save(Document document)
        {
            return await _documentRepository.Save(document);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _documentRepository.Delete(id);
        }

        [HttpDelete]
        public async Task<bool> DeleteAll()
        {
            return await _documentRepository.DeleteAll();
        }

    }
}
