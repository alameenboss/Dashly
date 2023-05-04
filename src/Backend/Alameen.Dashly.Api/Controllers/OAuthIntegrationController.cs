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
    public class OAuthIntegrationController : ControllerBase
    {
        private readonly IOAuthRepository _oAuthRepository;
        private readonly IMapper _mapper;

        public OAuthIntegrationController(IOAuthRepository oAuthRepository, IMapper mapper)
        {
            _oAuthRepository = oAuthRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OAuthIntegration>> GetAll()
        {
            return await _oAuthRepository.GetAll();
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateCodeById(int id, string code)
        {
            return await _oAuthRepository.UpdateCodeById(id, code);
        }

        [HttpPost]
        public async Task<bool> Insert(OAuthIntegration entity)
        {
            return await _oAuthRepository.Insert(entity);
        }

        [HttpGet("getclientid/{id}")]
        public async Task<IActionResult> GetClientIdById(int id)
        {
            var clientId = await _oAuthRepository.GetClientIdById(id);

            return Ok(new { clientId =  clientId });
        }
    }
}