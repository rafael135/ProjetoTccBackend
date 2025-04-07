using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Database.Requests.Exercise;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ILogger<ExerciseController> _logger;
        private readonly IExerciseService _exerciseService;

        public ExerciseController(ILogger<ExerciseController> logger, IExerciseService exerciseService)
        {
            this._logger = logger;
            this._exerciseService = exerciseService;
        }


        [Authorize(Roles = "Admin,Teacher")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "Admin,Teacher")]
        [HttpPost]
        public async Task<IActionResult> CreateNewExercise([FromBody] CreateExerciseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
