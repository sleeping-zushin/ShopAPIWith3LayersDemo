using BusinessLayer.IService;
using DataAccessLayer.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopAPIWith3Layers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVM loginInfo)
        {
            var loginResponse = await _userService.LoginAsync(loginInfo);
            if (loginResponse == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            return Ok(loginResponse);
        }
    }
}
