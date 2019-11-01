using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public AuthController(
            IAuthenticationService authenticationService,
            IAuthorizationService authorizationService,
            JwtService tokenService)
        {
            _authorizationService = authorizationService;
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly JwtService _tokenService;

        [HttpPost("refresh"), AllowAnonymous]
        public async Task<IActionResult> RefreshAuth(RefreshAccessRequest model)
        {
            var token = await _tokenService.VerifyRefreshToken(model.RefreshToken!);
            if (token == null)
            {
                return this.Error(Errors.BadRefreshToken());
            }

            var sub = token.Subject;
            var claims = (await _authorizationService.Authorize(sub)).ToList();

            var newAccessToken = _tokenService.GenerateAccessToken(claims);
            var newRefreshToken = await _tokenService.GenerateRefreshToken(sub);

            return Ok(new NewTokenResponse( newAccessToken, newRefreshToken, DateTime.Now));
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthRequest model)
        {
            if (!_authenticationService.AuthenticateUser(model.Username!, model.Password!))
            {
                return this.Error(Errors.NotYetRegisteredError());
            }

            var claims = (await _authorizationService.Authorize(model.Username!)).ToList();

            if (!claims.Any())
            {
                return this.Error(Errors.InvalidCredentials());
            }

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = await _tokenService.GenerateRefreshToken(model.Username!);

            return Ok(new NewTokenResponse(accessToken, refreshToken, DateTime.UtcNow));
        }

        [Authorize]
        [HttpGet("tokenTest")]
        public IActionResult Test()
        {
            return Ok(User.Claims.Where(c => c.Type == "role"));
        }
    }
}