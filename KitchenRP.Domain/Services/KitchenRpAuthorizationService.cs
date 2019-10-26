using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using KitchenRP.DataAccess;

namespace KitchenRP.Domain.Services
{
    public class KitchenRpAuthorizationService : IAuthorizationService
    {
        public KitchenRpAuthorizationService(KitchenRpDatabase database)
        {
            _database = database;
        }

        private readonly KitchenRpDatabase _database;

        public async Task<IEnumerable<Claim>> Authorize(string uid)
        {
            return await _database.UserGetClaims(uid);
        }
    }
}