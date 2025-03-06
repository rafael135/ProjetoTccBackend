using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
