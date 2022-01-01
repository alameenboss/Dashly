using Dashly.API.ConnectedServices.GitHub.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.ConnectedServices.GitHub
{
    public interface IGithubService
    {
        Task<IEnumerable<GitRepo>> GetAll();
    }
}
