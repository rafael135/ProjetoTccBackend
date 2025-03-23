using ProjetoTccBackend.Database;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;

namespace ProjetoTccBackend.Repositories
{
    public class ExerciseOutputRepository : GenericRepository<ExerciseOutput>, IExerciseOutputRepository
    {
        public ExerciseOutputRepository(TccDbContext dbContext) : base(dbContext)
        {
        }
    }
}
