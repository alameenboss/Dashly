using Dashly.API.ConnectedServices.GitHub.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dashly.API.ConnectedServices.GitHub
{
    public interface IGithubService
    {
        Task<IEnumerable<GitRepo>> GetAll();
    }

    public class GithubService : IGithubService
    {
        private const string baseUrl = "https://api.github.com";
        private const string GetUserRepoUrl = "users/{0}/repos?per_page=1000";
        private const string UserName = "alameenboss";
        public async Task<IEnumerable<GitRepo>> GetAll()
        {
            var formatedUrl = String.Format(GetUserRepoUrl, UserName);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Dashly","v.0.0.1"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync(formatedUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(result))
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<GitRepo>>(result);
                    }
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return null;

        }
    }
}
