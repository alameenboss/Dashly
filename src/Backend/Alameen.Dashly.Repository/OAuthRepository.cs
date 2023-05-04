using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Alameen.Dashly.Repository.Contract;
using Alameen.Dashly.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository
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
            var result = await _dbContext.OAuthIntegrations.ToListAsync();

            return result?.Select(x => new OAuthIntegration()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public async Task<bool> Insert(OAuthIntegration entity)
        {
            await _dbContext.OAuthIntegrations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<string> GetClientIdById(int id)
        {
            var entity = await _dbContext.OAuthIntegrations.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                return entity.ClientId;
            }

            return "";
        }

        public async Task<string> GetSecretByClientId(string clientId)
        {
            return (await _dbContext
                .OAuthIntegrations
                .FirstOrDefaultAsync(x =>
                    x.ClientId == clientId.ToLower()
                    )
                ).Secret;
        }

        public async Task<bool> UpdateCodeById(int id, string code)
        {
            var entity = await _dbContext.OAuthIntegrations.FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.Code = code;
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public Task<bool> DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}