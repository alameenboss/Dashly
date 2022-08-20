using Dashly.API.Data.Entity;

namespace Dashly.API.Feature.WebApps.Data.Entity
{
    public class Attachment : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsPrimary { get; set; }

        public int WebAppId { get; set; }
        public Webapp Webapp { get; set; }
    }
}