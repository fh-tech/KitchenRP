using System.Threading.Tasks;
using KitchenRP.Domain.Services;
using KitchenRP.Domain.Services.Internal;
using Microsoft.AspNetCore.Mvc;

namespace KitchenRP.Web.Controllers
{
    [ApiController, Route("user")]
    public class UserController: ControllerBase
    {
        private UserService _userService;

        public UserController(UserService service)
        {
            _userService = service;
        }
        
        [HttpGet]
        public IActionResult GetById(long id)
        {
            var user = _userService.UserById(id);
            return Ok(user);
        }
    }
}