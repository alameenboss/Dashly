namespace Dashly.API.Feature.OAuthIntegrations.Models
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


    public class OAuthResponse
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public int refresh_token_expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }

}
