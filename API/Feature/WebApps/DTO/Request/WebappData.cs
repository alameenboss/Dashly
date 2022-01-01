using System.Collections.Generic;

namespace Dashly.API.Feature.WebApps.DTO.Request
{
    public class WebappData
    {
        public string name { get; set; }
        public string hostedLocationUrl { get; set; }
        public string fullImageUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public List<string> tags { get; set; }
    }
}