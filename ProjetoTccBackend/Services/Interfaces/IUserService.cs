using ProjetoTccBackend.Database.Requests;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> RegisterUser(RegisterUserRequest request);
        Task<User?> LoginUser(LoginUserRequest request);
    }
}
