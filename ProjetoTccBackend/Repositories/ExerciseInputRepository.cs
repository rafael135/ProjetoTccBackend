using ProjetoTccBackend.Database;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;

namespace ProjetoTccBackend.Repositories
{
    public class ExerciseInputRepository : GenericRepository<ExerciseInput>, IExerciseInputRepository
    {
        public ExerciseInputRepository(TccDbContext dbContext) : base(dbContext)
        {
        }
    }
}
