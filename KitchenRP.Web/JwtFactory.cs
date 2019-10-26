using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KitchenRP.Web
{
    public class JwtService
    {
        public JwtService(string secret, int timeoutDuration)
        {
            _secret = secret;
            _timeoutDuration = timeoutDuration;
        }

        private readonly string _secret;
        private readonly int _timeoutDuration;

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var claimList = claims.ToList();
            var tokenHandler = new JwtSecurityTokenHandler();
            var claimDict = claimList.ToDictionary(c => c.Type, v => (object) v.Value);
            var key = Encoding.ASCII.GetBytes(_secret);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimList),
                Claims = claimDict,
                Expires = DateTime.UtcNow.AddMinutes(_timeoutDuration),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}