using BusinessLayer.IManager;
using Microsoft.AspNetCore.Mvc;
using ViewModelLayer.Account;

namespace RealTimeStock.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAccountManager _accountManager;

        public AuthController(IAccountManager accountManager)
        {

            _accountManager = accountManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModelVm model)
        {
            await _accountManager.Register(model);
            return Ok(new { Message = "Registration successful" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModelVm model)
        {
            // Validate user credentials (example logic)
            var token = await _accountManager.Login(model);
            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            return Ok(new { Token = token });
        }

    }
}
