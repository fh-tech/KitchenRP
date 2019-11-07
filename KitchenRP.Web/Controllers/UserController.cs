using System.Threading.Tasks;
using KitchenRP.Domain.Services;
using KitchenRP.Domain.Services.Internal;
using KitchenRP.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitchenRP.Web.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var user = await _userService.UserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> ActivateUser(UserActivationRequest model)
        {
            var user = await _userService.ActivateNewUser(model!.Uid, model.Email);
            
            if(user == null) return this.Error(Errors.UnableToActivateUser(model.Uid));
            var uri = $"user/{user.Id}";
            return Created(uri,
                new UserActivationResponse
                {
                    Id = user.Id,
                    Uri = uri
                });
        }
    }
}