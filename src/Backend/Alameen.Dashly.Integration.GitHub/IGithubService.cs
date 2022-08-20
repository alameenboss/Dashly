using Dashly.API.Feature.Github.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Github.Services
{
    public interface IGithubService
    {
        Task<IEnumerable<GitRepo>> GetAll();
    }
}