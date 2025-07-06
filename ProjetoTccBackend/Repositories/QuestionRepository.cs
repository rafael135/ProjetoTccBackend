using ProjetoTccBackend.Database;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;

namespace ProjetoTccBackend.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(TccDbContext dbContext) : base(dbContext)
        {
        }
    }
}
