﻿using System.Collections.Generic;

namespace Alameen.Dashly.API.Models
{
    public class CreateWebappRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string HostedLocationUrl { get; set; }

        public string PackagedZipFileUrl { get; set; }

        public string DemoUrl { get; set; }

        public string GithubUrl { get; set; }

        public List<AttachmentRequest> Attachments { get; set; }

        public List<TagRequest> Tags { get; set; }

        public string Type { get; set; }

        public string AuthorName { get; set; }

        public bool IsLocal { get; set; }

    }
}