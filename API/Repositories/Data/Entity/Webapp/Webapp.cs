using System.Collections.Generic;

namespace Dashly.API.Repositories.Data.Entity
{
    public class Webapp : BaseEntity
    {
        public Webapp()
        {
            Attachments = new List<Attachment>();
            Tags = new List<Tag>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string HostedLocationUrl { get; set; }
        public string PackagedZipFileUrl { get; set; }
        public string DemoUrl { get; set; }
        public string GithubUrl { get; set; }
        public string Type { get; set; }
        public string AuthorName { get; set; }
        public bool IsLocal { get; set; }

        public virtual List<Attachment> Attachments { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}