using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    /// <summary>
    /// Service interface for authentication-related operations.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Retrieves the currently logged-in user.
        /// </summary>
        /// <returns>
        /// The <see cref="User"/> object representing the logged-in user, or <c>null</c> if no user is logged in.
        /// </returns>
        public User? GetLoggedUser();
    }
}
