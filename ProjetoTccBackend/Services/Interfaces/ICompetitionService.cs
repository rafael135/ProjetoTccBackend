using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    /// <summary>
    /// Service interface for managing competitions.
    /// </summary>
    public interface ICompetitionService
    {
        /// <summary>
        /// Creates a new competition based on the provided request data.
        /// </summary>
        /// <param name="request">The competition creation request containing start and end times.</param>
        /// <returns>The created <see cref="Competition"/> object.</returns>
        Task<Competition> CreateCompetition(CompetitionRequest request);

        /// <summary>
        /// Retrieves the existing competition.
        /// </summary>
        /// <returns>The existing <see cref="Competition"/> object.</returns>
        Task<Competition> GetExistentCompetition();
    }
}
