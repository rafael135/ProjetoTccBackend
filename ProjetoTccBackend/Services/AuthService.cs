using System.Security.Claims;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly IUserRepository _userRepository;

        public AuthService(IHttpContextAccessor httpContextAcessor, IUserRepository userRepository)
        {
            this._httpContextAcessor = httpContextAcessor;
            this._userRepository = userRepository;
        }

        /// <inheritdoc/>
        public User? GetLoggedUser()
        {
            string? userId = this._httpContextAcessor.HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid);

            if(userId is null)
            {
                return null;
            }

            User? user = this._userRepository.GetById(userId);

            return user;
        }


    }
}
