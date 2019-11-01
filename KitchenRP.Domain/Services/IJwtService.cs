using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KitchenRP.Domain.Services
{
    public interface IJwtService
    {
        Task<JwtSecurityToken?> VerifyRefreshToken(string refreshToken);
        Task<string> GenerateRefreshToken(string sub);
        string GenerateAccessToken(IEnumerable<Claim> claims);

    }
}