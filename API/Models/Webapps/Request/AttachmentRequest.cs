﻿namespace Dashly.API.Models.Webapps.Request
{
    public class AttachmentRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsPrimary { get; set; }
    }
}