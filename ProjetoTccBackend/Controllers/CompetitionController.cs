using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Database.Responses.Competition;
using ProjetoTccBackend.Exceptions;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;
        private readonly ILogger<CompetitionController> _logger;

        public CompetitionController(ICompetitionService competitionService, ILogger<CompetitionController> logger)
        {
            this._competitionService = competitionService;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetExistentCompetition()
        {
            Competition? existentCompetition = await this._competitionService.GetExistentCompetition();

            if(existentCompetition is null)
            {
                return NoContent();
            }

            return Ok(existentCompetition);
        }


        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateNewCompetition([FromBody]CompetitionRequest request)
        {
            Competition? newCompetition = null;

            try
            {
                newCompetition = await this._competitionService.CreateCompetition(request);
            } catch(ExistentCompetitionException ex)
            {
                throw new FormException(new Dictionary<string, string>
                {
                    { "general", "Já existe uma competição marcada para a mesma data" }
                });
            }

            if(newCompetition == null)
            {
                throw new ErrorException("Não foi possível criar uma nova competição");
            }

            return CreatedAtAction(nameof(GetExistentCompetition), new { }, newCompetition);
        }
    }
}
