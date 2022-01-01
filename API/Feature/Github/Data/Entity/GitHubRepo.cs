using System;

namespace Dashly.API.Feature.Github.Data.Entity
{
    public class GitHubRepo
    {
        public int Id { get; set; }
        public string GitId { get; set; }
        public string NodeId { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string Description { get; set; }
        public bool Fork { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CloneUrl { get; set; }
        public string DownloadsUrl { get; set; }
        public string HtmlUrl { get; set; }
    }
}