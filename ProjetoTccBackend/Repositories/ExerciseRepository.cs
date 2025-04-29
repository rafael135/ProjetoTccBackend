using ProjetoTccBackend.Database;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoTccBackend.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(TccDbContext dbContext) : base(dbContext)
        {
        }
    }
}
