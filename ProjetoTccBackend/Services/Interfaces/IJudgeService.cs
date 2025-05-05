using ProjetoTccBackend.Database.Requests.Exercise;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Services.Interfaces
{
    public interface IJudgeService
    {
        /// <summary>
        /// Creates a new exercise in the Judge system using the provided exercise request data.
        /// </summary>
        /// <param name="exerciseRequest">The request object containing the details of the exercise to be created.</param>
        /// <returns>
        /// A Task that represents the asynchronous operation. The task result contains the UUID of the created exercise
        /// in the Judge system if the operation is successful; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method sends a POST request to the Judge API to create a new exercise. The payload includes the exercise's
        /// title, description, input, and output data. If the exercise is successfully created, the method returns the
        /// UUID of the created exercise. If the creation fails or the response is invalid, the method returns null.
        /// </remarks>
        Task<string?> CreateJudgeExerciseAsync(CreateExerciseRequest exerciseRequest);

        Task<Exercise?> GetExerciseByUuidAsync(string judgeUuid);

        Task<ICollection<Exercise>> GetExercisesAsync();

        Task<bool> CreateNewExerciseAsync(Exercise exercise);
    }
}
