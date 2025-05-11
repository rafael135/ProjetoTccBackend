using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface ICompetitionService
    {
        Task<Competition> CreateCompetition(CompetitionRequest request);
        Task<Competition> GetExistentCompetition();
    }
}
