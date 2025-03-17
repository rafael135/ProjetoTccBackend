using ApiEstoqueASP.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Filters;
using ProjetoTccBackend.Database.Requests;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Exceptions;
using ProjetoTccBackend.Database.Responses;

namespace ProjetoTccBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ITokenService tokenService, IUserService userService, ILogger<AuthController> logger)
        {
            this._tokenService = tokenService;
            this._userService = userService;
            this._logger = logger;
        }



        [HttpPost("register")]
        [ValidateModelState] // Valida o modelState do request recebido e retorna possíveis erros
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = await this._userService.RegisterUser(request);

            string jwtToken = this._tokenService.GenerateToken(user);
            
            UserRegisterResponse userResponse = new UserRegisterResponse()
            {
                Id = user.Id,
                Email = user.Email!,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName!,
                JoinYear = user.JoinYear,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed
            };

            return Ok(new
            {
                user = userResponse,
                token = jwtToken
            });
        }

        [HttpPost("login")]
        [ValidateModelState]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            var user = await this._userService.LoginUser(request);

            if (user is null)
            {
                return BadRequest(
                    error: new {
                        
                    }
                );   
            }

            return Ok(user);
        }
    }
}
