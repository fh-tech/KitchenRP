using System;
using KitchenRP.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KitchenRP.Domain
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddKitchenRpDomainServices(this IServiceCollection services, Action<KitchenRpServiceOptions> configurer)
        {
            var options = new KitchenRpServiceOptions();
            configurer.Invoke(options);
            services.AddScoped(options.AuthService);
            services.AddScoped<IAuthorizationService, KitchenRpAuthorizationService>();
            return services;
        }
    }
}