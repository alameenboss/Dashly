﻿namespace Dashly.API.Feature.OAuthIntegrations.Data.Entity
{
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