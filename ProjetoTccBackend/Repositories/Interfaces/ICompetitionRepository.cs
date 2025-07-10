using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Repositories.Interfaces
{
    /// <summary>
    /// Defines repository operations specific to the <see cref="Competition"/> entity.
    /// Extends the generic repository interface with methods for handling competition-related data.
    /// </summary>
    public interface ICompetitionRepository : IGenericRepository<Competition>
    {
        /// <summary>
        /// Retrieves all questions associated with a specific competition.
        /// </summary>
        /// <param name="competitionId">The unique identifier of the competition.</param>
        /// <returns>A collection of <see cref="Question"/> objects related to the competition.</returns>
        Task<ICollection<Question>> GetCompetitionQuestions(int competitionId);
    }
}
