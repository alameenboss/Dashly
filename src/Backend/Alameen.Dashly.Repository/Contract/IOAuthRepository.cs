using Alameen.Dashly.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Repository.Contract
{
    public interface IOAuthRepository
    {
        Task<IEnumerable<OAuthIntegration>> GetAll();

        Task<bool> AddOAuthApp(string name, string tokenUrl, string appid, string clientid, string secret);

        Task<bool> UpdateOAuthCode(string name, string code);

        Task<string> GetOAuthClientIdByName(string name);

        Task<OAuthIntegration> GetOAuthAppSecret(string name);
    }
}