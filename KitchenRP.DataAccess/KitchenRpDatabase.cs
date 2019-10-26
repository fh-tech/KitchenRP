using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KitchenRP.DataAccess
{
    public class KitchenRpDatabase
    {
        private readonly KitchenRpContext _ctx;

        public KitchenRpDatabase(KitchenRpContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Claim>> UserGetClaims(string uid)
        {
            var user = await _ctx.Users.Where(u => u.Sub == uid)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();

            return user != null
                ? new[]
                {
                    new Claim("sub", user.Sub),
                    new Claim("scope", user.Role.Role),
                }
                : new Claim[] { };
        }
    }
}