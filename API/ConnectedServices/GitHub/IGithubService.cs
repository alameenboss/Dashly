using Dashly.API.ConnectedServices.GitHub.Models;
using Dashly.API.Feature.OAuthIntegrations.Models;
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
        private const string GetUserRepoUrl = "users/{0}/repos?per_page=100";
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

        public async Task<OAuthResponse> GetToken()
        {
            var formatedUrl = String.Format(GetUserRepoUrl, UserName);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://github.com");
                var content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("client_id", "Iv1.5eb6352ffa77a621"),
                    new KeyValuePair<string, string>("client_secret", "c047d5cdb57752d4e989708a0a6d0f68bc26543e"),
                    new KeyValuePair<string, string>("code", "5019b55935a5fa1a7754")
                });
                var response = await client.PostAsync("login/oauth/access_token", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(result))
                    {
                        return JsonConvert.DeserializeObject<OAuthResponse>(result);
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
