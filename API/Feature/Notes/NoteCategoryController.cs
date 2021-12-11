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
    public class NoteCategoryController : ControllerBase
    {
        private readonly INoteCategoryRepository _noteCategoryRepository;
        private readonly IMapper _mapper;

        public NoteCategoryController(INoteCategoryRepository noteCategoryRepository, IMapper mapper)
        {
            _noteCategoryRepository = noteCategoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteCategory>> GetAllByCategoryId()
        {
            return await _noteCategoryRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<NoteCategory> GetById(int id)
        {
            return await _noteCategoryRepository.GetById(id);
        }

        [HttpPost]
        public async Task<int> Insert(NoteCategory noteCategory)
        {
            return await _noteCategoryRepository.Insert(noteCategory);
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(NoteCategory noteCategory, int id)
        {
            return await _noteCategoryRepository.Update(noteCategory, id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _noteCategoryRepository.Delete(id);
        }

        [HttpDelete]
        public async Task<bool> DeleteAll()
        {
            return await _noteCategoryRepository.DeleteAll();
        }
    }
}