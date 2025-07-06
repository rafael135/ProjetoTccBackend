using ProjetoTccBackend.Database.Requests.Competition;
using ProjetoTccBackend.Database.Responses.Competition;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IGroupAttemptService
    {
        Task<ExerciseSubmissionResponse> SubmitExerciseAttempt(GroupExerciseAttemptRequest request);
    }
}
