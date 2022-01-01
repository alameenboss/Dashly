namespace Dashly.API.Feature.OAuthIntegrations.Data.Entity
{
    public class OAuthIntegration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TokenUrl { get; set; }
        public string AppId { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string Code { get; set; }
    }
}