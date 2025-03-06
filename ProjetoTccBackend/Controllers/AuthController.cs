using ApiEstoqueASP.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Filters;
using ProjetoTccBackend.Database.Requests;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Exceptions;

namespace ProjetoTccBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }



        [HttpPost("/register")]
        [ValidateModelState] // Valida o modelState do request recebido e retorna possíveis erros
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = await this._userService.RegisterUser(request);

            if(user is null)
            {
                throw new FormException(new Dictionary<string, string>()
                {
                    { "email", "E-mail já utilizado" }
                });
            }

            string jwtToken = this._tokenService.GenerateToken(user);

            return Ok(new
            {
                user,
                token = jwtToken
            });
        }

        [HttpPost("/login")]
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
