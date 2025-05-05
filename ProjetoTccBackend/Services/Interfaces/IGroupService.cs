using ProjetoTccBackend.Models;
using ProjetoTccBackend.Database.Requests.Group;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IGroupService
    {
        /// <summary>
        /// Creates a new group and associates it with the logged-in user.
        /// </summary>
        /// <param name="groupRequest">An object containing the details of the group to be created.</param>
        /// <returns>
        /// A <see cref="Group"/> object representing the newly created group.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown if the logged-in user is not authenticated.
        /// </exception>
        Task<Group> CreateGroupAsync(CreateGroupRequest groupRequest);


        /// <summary>
        /// Changes the name of an existing group.
        /// </summary>
        /// <param name="groupRequest">An object containing the group ID and the new name for the group.</param>
        /// <returns>
        /// A <see cref="Group"/> object with the updated name, or <c>null</c> if the group does not exist.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown if the logged-in user is not authorized to change the name of the specified group.
        /// </exception>
        Group? ChangeGroupName(ChangeGroupNameRequest groupRequest);


        /// <summary>
        /// Retrieves a group by its ID if the logged-in user has access to it.
        /// </summary>
        /// <param name="id">The ID of the group to retrieve.</param>
        /// <returns>
        /// A <see cref="Group"/> object representing the group with the specified ID, 
        /// or <c>null</c> if the group does not exist.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Thrown if the logged-in user does not have access to the specified group.
        /// </exception>
        Group? GetGroupById(int id);
    }
}
