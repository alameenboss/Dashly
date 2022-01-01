namespace Dashly.API.Repositories.Data.Entity
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public int WebAppId { get; set; }
        public Webapp Webapp { get; set; }

    }
}