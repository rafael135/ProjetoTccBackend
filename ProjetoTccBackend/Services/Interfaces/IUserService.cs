using ProjetoTccBackend.Database.Requests.Auth;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Exceptions;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the currently logged-in user from the HTTP context.
        /// </summary>
        /// <returns>The logged-in <see cref="User"/> object.</returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown when the user is not authenticated or the user ID cannot be found in the claims.
        /// </exception>
        User GetHttpContextLoggerUser();

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="user">The <see cref="RegisterUserRequest"/> object containing the user's registration details.</param>
        /// <returns>The newly created <see cref="User"/> object.</returns>
        /// <exception cref="FormException">
        /// Thrown when the email is already in use or if there are errors during user creation.
        /// </exception>
        Task<User> RegisterUserAsync(RegisterUserRequest request);

        /// <summary>
        /// Authenticates a user using their email and password.
        /// </summary>
        /// <param name="usr">The <see cref="LoginUserRequest"/> object containing the user's login credentials.</param>
        /// <returns>The authenticated <see cref="User"/> object.</returns>
        /// <exception cref="FormException">
        /// Thrown when the email does not exist in the system or the password is incorrect.
        /// </exception>
        Task<User> LoginUserAsync(LoginUserRequest request);
    }
}
