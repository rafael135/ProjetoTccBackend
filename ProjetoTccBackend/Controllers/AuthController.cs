using ApiEstoqueASP.Services;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Filters;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Exceptions;
using ProjetoTccBackend.Database.Requests.Auth;
using ProjetoTccBackend.Database.Responses.Auth;

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
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="request">The <see cref="RegisterUserRequest"/> object containing the user's registration details.</param>
        /// <returns>
        /// Returns an <see cref="IActionResult"/> containing the registered user's details and a JWT token.
        /// On success, returns a 200 OK response with the user and token.
        /// On failure, returns appropriate error responses such as 400 Bad Request or 500 Internal Server Error.
        /// </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Auth/register
        ///     {
        ///         "ra": "12345",
        ///         "userName": "JohnDoe",
        ///         "email": "johndoe@example.com",
        ///         "joinYear": 2023,
        ///         "accessCode": "optionalCode",
        ///         "role": "User",
        ///         "password": "SecurePassword123"
        ///     }
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "user": {
        ///             "id": "userId",
        ///             "userName": "JohnDoe",
        ///             "email": "johndoe@example.com",
        ///             "emailConfirmed": false,
        ///             "joinYear": 2023,
        ///             "phoneNumber": null,
        ///             "phoneNumberConfirmed": false
        ///         },
        ///         "token": "jwtTokenString"
        ///     }
        /// </remarks>
        /// <response code="200">Returns the registered user and token</response>
        /// <response code="400">If the request is invalid</response>
        /// <response code="500">If an internal server error occurs</response>
        [HttpPost("register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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
        /// Authenticates a user using their email and password.
        /// </summary>
        /// <param name="request">The <see cref="LoginUserRequest"/> object containing the user's login credentials.</param>
        /// <returns>
        /// Returns an <see cref="IActionResult"/> containing the authenticated user's details and a JWT token.
        /// On success, returns a 200 OK response with the user and token.
        /// On failure, returns appropriate error responses such as 400 Bad Request or 500 Internal Server Error.
        /// </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Auth/login
        ///     {
        ///         "email": "johndoe@example.com",
        ///         "password": "SecurePassword123"
        ///     }
        /// 
        /// Sample response:
        /// 
        ///     {
        ///         "user": {
        ///             "id": "userId",
        ///             "userName": "JohnDoe",
        ///             "email": "johndoe@example.com",
        ///             "emailConfirmed": false,
        ///             "joinYear": 2023,
        ///             "phoneNumber": null,
        ///             "phoneNumberConfirmed": false
        ///         },
        ///         "token": "jwtTokenString"
        ///     }
        /// </remarks>
        /// <response code="200">Returns the authenticated user and token</response>
        /// <response code="400">If the request is invalid</response>
        /// <response code="500">If an internal server error occurs</response>
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
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
