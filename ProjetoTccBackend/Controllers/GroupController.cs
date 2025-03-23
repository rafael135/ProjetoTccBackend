using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Database.Requests.Group;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            this._groupService = groupService;
        }


        [HttpPost()]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupRequest request)
        {
            var group = await this._groupService.CreateGroupAsync(request);
            return Ok(new
            {
                group.Id,
                group.Name
            });
        }
    }
}
