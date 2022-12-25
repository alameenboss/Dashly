using Alameen.Dashly.Integration.GitHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alameen.Dashly.Integration.GitHub
{
    public interface IGithubService
    {
        Task<IEnumerable<GitRepo>> GetAll();
    }
}