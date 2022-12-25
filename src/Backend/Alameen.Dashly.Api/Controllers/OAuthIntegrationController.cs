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

        [HttpPut("{name}")]
        public async Task<bool> UpdateOAuthCode(string name, OAuthIntegration oAuthIntegration)
        {
            return await _oAuthRepository.UpdateOAuthCode(name, oAuthIntegration.Code);
        }

        [HttpPost]
        public async Task<bool> AddOAuthApp(OAuthIntegration oAuthIntegration)
        {
            return await _oAuthRepository.AddOAuthApp(oAuthIntegration.Name, oAuthIntegration.TokenUrl, oAuthIntegration.AppId, oAuthIntegration.ClientId, oAuthIntegration.Secret);
        }

        [HttpGet("getclientid/{name}")]
        public async Task<IActionResult> GetOAuthClientIdByName(string name)
        {
            var clientId = await _oAuthRepository.GetOAuthClientIdByName(name);

            return Ok(new { clientId });
        }
    }
}