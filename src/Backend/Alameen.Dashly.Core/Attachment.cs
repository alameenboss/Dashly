namespace Alameen.Dashly.Core
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