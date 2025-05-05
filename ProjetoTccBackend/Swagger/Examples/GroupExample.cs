using ProjetoTccBackend.Models;
using ProjetoTccBackend.Swagger.Interfaces;

namespace ProjetoTccBackend.Swagger.Examples
{
    public class GroupExample : ISwaggerExampleProvider<Group>
    {
        public Group GetExample() => new Group()
        {
            Id = 1,
            Name = "Group name",
        };
    }
}
