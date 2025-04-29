using Microsoft.AspNetCore.SignalR;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Hubs
{
    public class CompetitionHub : Hub
    {
        private readonly IGroupAttemptService _groupAttemptService;

        public CompetitionHub(IGroupAttemptService groupAttemptService)
        {
            this._groupAttemptService = groupAttemptService;
        }

        public async Task Ping()
        {
            await Clients.Caller.SendAsync("Pong", new { message = "Pong" });
        }

        public async Task SendExerciseAttempt()
        {

        }
    }
}
