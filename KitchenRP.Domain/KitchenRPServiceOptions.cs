using System;
using KitchenRP.Domain.Services;

namespace KitchenRP.Domain
{
    public class KitchenRpServiceOptions
    {
        public void LdapConfiguration(string ldapHost, ushort ldapPort, string ldapSearchBase, string ldapUserSearch)
        {
            _authService = _ => new LdapAuthService(ldapHost, ldapPort, ldapSearchBase, ldapUserSearch);
        }

        private Func<IServiceProvider, IAuthenticationService> _authService;
        
        internal Func<IServiceProvider, IAuthenticationService> AuthService =>
            _authService ?? throw new ServiceNotInitializedException();
        
    }

    public class ServiceNotInitializedException : Exception { }
}