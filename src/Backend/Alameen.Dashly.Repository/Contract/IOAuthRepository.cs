using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
{
    public interface IOAuthRepository
    {
        Task<IEnumerable<OAuthIntegration>> GetAll();
        Task<string> GetClientIdById(int id);
        Task<string> GetSecretByClientId(string clientId);
        Task<bool> Insert(OAuthIntegration entity);
        Task<bool> UpdateCodeById(int id, string code);
        Task<bool> DeleteById(int id);
    }
}