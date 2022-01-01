using Dashly.API.Feature.OAuthIntegrations.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.OAuthIntegrations.Data
{
    public interface IOAuthRepository
    {
        Task<IEnumerable<OAuthIntegration>> GetAll();
        Task<bool> AddOAuthApp(string name,string tokenUrl, string appid, string clientid, string secret);
        Task<bool> UpdateOAuthCode(string name, string code);
        Task<string> GetOAuthClientIdByName(string name);
        Task<OAuthIntegration> GetOAuthAppSecret(string name);
    }
}