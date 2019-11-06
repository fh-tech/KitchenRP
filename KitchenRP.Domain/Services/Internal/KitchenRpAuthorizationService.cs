using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KitchenRP.Domain.Services.Internal
{
    public class KitchenRpAuthorizationService : IAuthorizationService
    {
        public KitchenRpAuthorizationService(IUserService users)
        {
            _users = users;
        }

        private readonly IUserService _users;

        public async Task<IEnumerable<Claim>> Authorize(string uid)
        {
            //TODO: make a real implementation
            return await Task.Run(() => new []
            {
                new Claim("sub", "if17b094"), 
                new Claim(ClaimTypes.Role, "admin"),
            });
            return await _users.GetClaimsForUser(uid);
        }
    }
}