using Microsoft.AspNetCore.Mvc;
using MyPocketAPI.Data.Dto;
using MyPocketAPI.Services.Interfaces;

namespace MyPocketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            var user = await _userService.GetUserAsync(login, password);

            if (user == null)
            {
                return Unauthorized("Usuario o contraseña inválidos");
            }

            var token = _accountService.GenerateJwtToken(user);

            var userDto = new UserDto
            {               
                Id = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone= user.Phone,
                Token = token
            };

            return Ok(userDto);
        }

        // Otros métodos para SignIn, Logout, ForgotPassword, etc.
    }

}
