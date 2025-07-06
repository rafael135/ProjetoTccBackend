using Microsoft.AspNetCore.SignalR;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Database.Requests.Group;
using ProjetoTccBackend.Database.Requests.Competition;

namespace ProjetoTccBackend.Hubs
{
    public class CompetitionHub : Hub
    {
        private readonly IGroupAttemptService _groupAttemptService;
        private readonly ICompetitionService _competitionService;

        public CompetitionHub(IGroupAttemptService groupAttemptService, ICompetitionService competitionService)
        {
            this._groupAttemptService = groupAttemptService;
            this._competitionService = competitionService;
        }

        public async Task Ping()
        {
            await Clients.Caller.SendAsync("Pong", new { message = "Pong" });
        }

        public async Task SendExerciseAttempt(GroupExerciseAttemptRequest request)
        {
            this._groupAttemptService.SubmitExerciseAttempt(request);
        }
    }
}
