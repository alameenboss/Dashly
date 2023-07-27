namespace OnOffSoftware.Dashly.Core
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public int WebAppId { get; set; }
        public Webapp Webapp { get; set; }
    }
}