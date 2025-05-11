using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Exceptions;

namespace ProjetoTccBackend.Services
{
    public class CompetitionService : ICompetitionService
    {
        public ICompetitionRepository _competitionRepository { get; set; }

        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            this._competitionRepository = competitionRepository;
        }

        public async Task<Competition> CreateCompetition(CompetitionRequest request)
        {
            Competition? existentCompetition = this._competitionRepository.Find(c => c.StartTime.Date.Equals(request.StartTime.Date)).FirstOrDefault();

            if(existentCompetition is not null)
            {
                throw new ExistentCompetitionException();
            }

            Competition newCompetition = new Competition()
            {
                StartTime = request.StartTime,
                EndTime = request.EndTime,
            };

            this._competitionRepository.Add(newCompetition);

            return newCompetition;
        }

        public async Task<Competition?> GetExistentCompetition()
        {
            Competition? existentCompetition = this._competitionRepository.Find(c => c.StartTime.Ticks > DateTime.Now.Ticks).FirstOrDefault();

            return existentCompetition;
        }
    }
}
