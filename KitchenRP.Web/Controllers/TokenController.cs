using System;
using System.Linq;
using System.Threading.Tasks;
using KitchenRP.Domain.Services;
using KitchenRP.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IAuthorizationService = KitchenRP.Domain.Services.IAuthorizationService;

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
                return this.Error(Errors.NotYetRegisteredError());
            }

            var claims = (await _authorizationService.Authorize(model!.Username)).ToList();
            if (!claims.Any())
            {
                return this.Error(Errors.InvalidCredentials());
            }

            var token = _tokenService.GenerateToken(claims);
            return Ok(new NewTokenResponse
            {
                Token = token,
                Iat = DateTime.UtcNow
            });
        }

        [Authorize(Roles = "admin")]
        [HttpGet("tokenTest")]
        public IActionResult Test()
        {
            return Ok("OK");
        }
    }
}