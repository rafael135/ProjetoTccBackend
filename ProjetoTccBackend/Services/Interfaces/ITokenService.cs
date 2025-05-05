using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates a JSON Web Token (JWT) for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the token is being generated.</param>
        /// <returns>A string representation of the generated JWT.</returns>
        /// <remarks>
        /// The token includes claims such as the user's email, ID, role, and a unique identifier (JTI).
        /// It is signed using a symmetric security key and is valid for 5 days.
        /// </remarks>
        public string GenerateToken(User user);
    }
}
