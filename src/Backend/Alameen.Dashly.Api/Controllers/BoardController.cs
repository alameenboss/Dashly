using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardController(IBoardRepository boardRepository, IMapper mapper)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Board>> GetAll()
        {
            return await _boardRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Board> GetById(int id)
        {
            return await _boardRepository.GetById(id);
        }

        [HttpPost]
        public async Task<bool> Save(Board board)
        {
            return await _boardRepository.Save(board);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _boardRepository.Delete(id);
        }

        [HttpDelete]
        public async Task<bool> DeleteAll()
        {
            return await _boardRepository.DeleteAll();
        }
    }
}