using System;

namespace KitchenRP.Web.Models
{
    public class NewTokenResponse
    {
        public string Token { get; set; }
        public DateTime Iat { get; set; }
    }
}