using ProjetoTccBackend.Database.Requests.Group;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Services
{
    public class GroupService : IGroupService
    {
        public Task<Group> CreateGroupAsync(CreateGroupRequest group)
        {
            throw new NotImplementedException();
        }
    }
}
