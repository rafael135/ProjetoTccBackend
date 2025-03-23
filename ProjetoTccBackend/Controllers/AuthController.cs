using ApiEstoqueASP.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Filters;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Exceptions;
using ProjetoTccBackend.Database.Responses;
using ProjetoTccBackend.Database.Requests.Auth;

namespace ProjetoTccBackend.Controllers
{
    /// <summary>
    /// Controlador responsável pela autenticação de usuários.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// Construtor do AuthController.
        /// </summary>
        /// <param name="tokenService">Serviço de geração de token.</param>
        /// <param name="userService">Serviço de gerenciamento de usuários.</param>
        /// <param name="logger">Logger para registrar informações e erros.</param>
        public AuthController(ITokenService tokenService, IUserService userService, ILogger<AuthController> logger)
        {
            this._tokenService = tokenService;
            this._userService = userService;
            this._logger = logger;
        }

        /// <summary>
        /// Registra um novo usuário.
        /// </summary>
        /// <param name="request">Dados do usuário a ser registrado.</param>
        /// <returns>Retorna o usuário registrado e o token JWT.</returns>
        [HttpPost("register")]
        [ValidateModelState] // Valida o modelState do request recebido e retorna possíveis erros
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = await this._userService.RegisterUserAsync(request);

            string jwtToken = this._tokenService.GenerateToken(user);

            UserResponse userResponse = new UserResponse()
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


        /// <summary>
        /// Autentica um usuário existente.
        /// </summary>
        /// <param name="request">Dados do usuário para login.</param>
        /// <returns>Retorna o usuário autenticado e o token JWT.</returns>
        [HttpPost("login")]
        [ValidateModelState]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            User user = await this._userService.LoginUserAsync(request);

            UserResponse userResponse = new UserResponse()
            {
                Id = user.Id,
                Email = user.Email!,
                EmailConfirmed = user.EmailConfirmed,
                UserName = user.UserName!,
                JoinYear = user.JoinYear,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed
            };

            string jwtToken = this._tokenService.GenerateToken(user);

            return Ok(new
            {
                user = userResponse,
                token = jwtToken
            });
        }
    }
}
