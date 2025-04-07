using ProjetoTccBackend.Database.Requests.Exercise;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<Exercise> CreateExercise(CreateExerciseRequest exercise);
    }
}
