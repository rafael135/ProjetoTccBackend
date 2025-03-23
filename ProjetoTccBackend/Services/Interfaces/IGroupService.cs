using ProjetoTccBackend.Models;
using ProjetoTccBackend.Database.Requests.Group;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IGroupService
    {
        Task<Group> CreateGroupAsync(CreateGroupRequest group);
    }
}
