﻿using System.Collections.Generic;

namespace OnOffSoftware.Dashly.API.Models
{
    public class UpdateWebappRequest
    {
        public int Id { get; set; }

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