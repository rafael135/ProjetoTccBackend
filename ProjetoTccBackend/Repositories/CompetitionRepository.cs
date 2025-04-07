using ProjetoTccBackend.Database;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ProjetoTccBackend.Repositories
{
    public class CompetitionRepository : GenericRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(TccDbContext dbContext) : base(dbContext)
        {
        }
    }
}
