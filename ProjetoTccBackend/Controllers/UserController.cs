using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoTccBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("info/{userId}")]
        public async Task<IActionResult> GetUserInfo(int userId)
        {
            Task[] tasks = [];
            await Task.WhenAll(tasks);

            return Ok();
        }
    }
}
