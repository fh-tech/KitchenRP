using System;

namespace KitchenRP.Web.Models
{
    public class NewTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Iat { get; set; }
    }
}