using AutoMapper;
using Dashly.API.Data.Entity;
using Dashly.API.Feature.Github.Data.Entity;
using Dashly.API.Feature.Github.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Feature.Github
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProcessorController : ControllerBase
    {
        private readonly IGithubService _githubService;
        private readonly IMapper _mapper;
        private DashlyContext _context;

        public GithubProcessorController(IGithubService githubService, DashlyContext context,
            IMapper mapper)
        {
            _githubService = githubService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GitHubRepo>>> GetAll()
        {
            if (!_context.GitHubRepos.Any())
            {
                var gitRepos = await _githubService.GetAll();

                // var entity = _mapper.Map<GitHubRepo>(gitRepos);

                var gitHubReposList = new List<GitHubRepo>();
                gitRepos.ToList().ForEach(repo =>
                {
                    gitHubReposList.Add(new GitHubRepo()
                    {
                        GitId = repo.id.ToString(),
                        NodeId = repo.node_id,
                        Name = repo.name,
                        IsPrivate = repo._private,
                        Description = repo.description,
                        Fork = repo.fork,
                        CreatedAt = repo.created_at,
                        CloneUrl = repo.clone_url,
                        DownloadsUrl = repo.downloads_url,
                        HtmlUrl = repo.html_url
                    });
                });

                await _context.GitHubRepos.AddRangeAsync(gitHubReposList);

                await _context.SaveChangesAsync();
            }

            var gitHubRepos = _context.GitHubRepos.ToList();

            return Ok(gitHubRepos);
        }
    }
}