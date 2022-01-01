using Dashly.API.Feature.OAuthIntegrations.Models;
using Dashly.API.Helpers;
using Dashly.API.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Dashly.API.Feature.OAuthIntegrations.Data
{
    public class OAuthRepository : IOAuthRepository
    {
        private readonly DashlyContext _dbContext;
        private readonly IContextResolver _contextResolver;

        public OAuthRepository(DashlyContext dbContext, IContextResolver contextResolver)
        {
            _dbContext = dbContext;
            _contextResolver = contextResolver;
        }

        public async Task<IEnumerable<OAuthIntegration>> GetAll()
        {
            var result =  await _dbContext.OAuthIntegrations.ToListAsync();

            return result?.Select(x => new OAuthIntegration()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task<bool> AddOAuthApp(string name, string tokenurl, string appid, string clientid, string secret)
        {
            var oAuthIntegration = new OAuthIntegration()
            {
                Name = name,
                TokenUrl = tokenurl,
                AppId = appid,
                ClientId = clientid,
                Secret = secret
            };

            await _dbContext.OAuthIntegrations.AddAsync(oAuthIntegration);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<string> GetOAuthClientIdByName(string name)
        {
            var response = await _dbContext.OAuthIntegrations.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (response != null)
            {
                return response.ClientId;
            }

            return "";
        }

        public async Task<OAuthIntegration> GetOAuthAppSecret(string name)
        {
            return await _dbContext.OAuthIntegrations.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
        public async Task<bool> UpdateOAuthCode(string name, string code)
        {
            var response = await _dbContext.OAuthIntegrations.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (response != null)
            {
                response.Code = code;
                _dbContext.Update(response);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        
    }
}
