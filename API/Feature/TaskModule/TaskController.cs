using AutoMapper;
using Dashly.API.Feature.TaskModule.Data;
using Dashly.API.Feature.TaskModule.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.TaskModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _taskRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Tasks> GetById(int id)
        {
            return await _taskRepository.GetById(id);
        }

        [HttpPost]
        public async Task<bool> Save(Tasks task)
        {
            return await _taskRepository.Save(task);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _taskRepository.Delete(id);
        }

        [HttpDelete]
        public async Task<bool> DeleteAll()
        {
            return await _taskRepository.DeleteAll();
        }
    }
}