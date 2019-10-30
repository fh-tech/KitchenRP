using System;
using KitchenRP.DataAccess;
using KitchenRP.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KitchenRP.Domain
{
    public class KitchenRpServiceOptions
    {
        public void LdapConfiguration(Action<LdapConfiguration> configuration)
        {
            _authService = _ =>
            {
                var cfg = new LdapConfiguration();
                configuration.Invoke(cfg);
                return new LdapAuthService(cfg.Host, cfg.Port, cfg.SearchBase, cfg.UserSearch);
            };
        }

        public void JwtConfiguration(Action<JwtConfiguration> configuration)
        {
            _jwtService = services =>
            {
                var cfg = new JwtConfiguration();
                configuration.Invoke(cfg);
                var dbService = services.GetService<KitchenRpDatabase>();
                return new JwtService(dbService, cfg.AccessSecret, cfg.AccessTimeout, cfg.RefreshSecret,
                    cfg.RefreshTimeout);
            };
        }

        private Func<IServiceProvider, IAuthenticationService> _authService;
        private Func<IServiceProvider, JwtService> _jwtService;

        internal Func<IServiceProvider, IAuthenticationService> AuthService =>
            _authService ?? throw new ServiceNotInitializedException();
        
        internal Func<IServiceProvider, JwtService> JwtService =>
            _jwtService ?? throw new ServiceNotInitializedException();
    }

    public class LdapConfiguration
    {
        public string Host { get; set; }
        public ushort Port { get; set; }
        public string SearchBase { get; set; }
        public string UserSearch { get; set; }
    }

    public class JwtConfiguration
    {
        public byte[] AccessSecret { get; set; } 
        public byte[] RefreshSecret { get; set; }         
        public int AccessTimeout { get; set; } 
        public int RefreshTimeout { get; set; } 
    }
    
    public class ServiceNotInitializedException : Exception
    {
    }
}