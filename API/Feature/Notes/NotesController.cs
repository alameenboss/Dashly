using AutoMapper;
using Dashly.API.Repositories.Data.Entity.Notes;
using Dashly.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NotesController(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
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
    }
}