using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KitchenRP.Domain;
using KitchenRP.Domain.Services;
using KitchenRP.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitchenRP.Web.Controllers
{
    [ApiController]
    [Route("token")]
    public class AuthController : ControllerBase
    {
        public AuthController(IAuthenticationService authenticationService, IAuthorizationService authorizationService,
            JwtService tokenService)
        {
            _authorizationService = authorizationService;
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly JwtService _tokenService;

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthRequest model)
        {
            if (!_authenticationService.AuthenticateUser(model!.Username, model!.Password))
            {
                return Errors.NotYetRegisteredError();
            }

            var claims = (await _authorizationService.Authorize(model!.Username)).ToList();
            if (!claims.Any())
            {
                return Errors.InvalidCredentials();
            }

            var token = _tokenService.GenerateToken(claims);
            return Ok(new NewTokenResponse
            {
                Token = token,
                Iat = DateTime.UtcNow
            });
        }
    }
}