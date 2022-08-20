using AutoMapper;
using Dashly.API.Feature.DataImport;
using Dashly.API.Feature.Notes.Data.Entity;
using Dashly.API.Feature.Notes.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace Dashly.API.Feature.Notes
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        private readonly IDataImport<Note> _dataImport;
        public NotesController(INoteRepository noteRepository, 
            IDataImport<Note> dataImport,
            IMapper mapper)
        {
            _noteRepository = noteRepository;
            _dataImport = dataImport;
            _mapper = mapper;
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IEnumerable<Note>> GetAllByCategoryId(int categoryId)
        {
            return await _noteRepository.GetAllByCategoryId(categoryId);
        }

        [HttpGet("{id}")]
        public async Task<Note> GetById(int id)
        {
            return await _noteRepository.GetById(id);
        }

        [HttpPost]
        public async Task<int> Insert(Note note)
        {
            return await _noteRepository.Insert(note);
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(Note note, int id)
        {
            return await _noteRepository.Update(note, id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _noteRepository.Delete(id);
        }

        [HttpDelete("category/{categoryId}")]
        public async Task<bool> DeleteAll(int categoryId)
        {
            return await _noteRepository.DeleteAllByCategoryId(categoryId);
        }

        [HttpDelete]
        public async Task<bool> DeleteAll()
        {
            return await _noteRepository.DeleteAll();
        }

        [HttpPut("import"), DisableRequestSizeLimit]
        public async Task Import(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string data = Encoding.UTF8.GetString(fileBytes);
                var notes = await _dataImport.ExecuteAsync(data);
                await _noteRepository.Import(notes);
            }
        }
    }
}