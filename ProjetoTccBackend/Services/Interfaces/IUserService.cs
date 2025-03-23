using ProjetoTccBackend.Database.Requests.Auth;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(RegisterUserRequest request);
        Task<User> LoginUserAsync(LoginUserRequest request);
    }
}
