using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KitchenRP.Domain.Services
{
    public interface IAuthorizationService
    {
        Task<IEnumerable<Claim>> Authorize(string uid);
    }
}