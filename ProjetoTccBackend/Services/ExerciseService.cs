using ProjetoTccBackend.Database.Requests.Exercise;
using ProjetoTccBackend.Exceptions;
using ProjetoTccBackend.Models;
using ProjetoTccBackend.Repositories.Interfaces;
using ProjetoTccBackend.Services.Interfaces;

namespace ProjetoTccBackend.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseInputRepository _exerciseInputRepository;
        private readonly IExerciseOutputRepository _exerciseOutputRepository;

        public ExerciseService(IExerciseRepository exerciseRepository, IExerciseInputRepository exerciseInputRepository, IExerciseOutputRepository exerciseOutputRepository)
        {
            this._exerciseRepository = exerciseRepository;
            _exerciseInputRepository = exerciseInputRepository;
            _exerciseOutputRepository = exerciseOutputRepository;
        }

        public async Task<Exercise> CreateExercise(CreateExerciseRequest request)
        {
            var inputsRequest = request.Inputs.ToList();
            var outputsRequest = request.Outputs.ToList();

            Exercise exercise = new Exercise()
            {
                Title = request.Title,
                Description = request.Description,
                EstimatedTime = request.EstimatedTime,
            };

            this._exerciseRepository.Add(exercise);

            var inputs = new List<ExerciseInput>();
            var outputs = new List<ExerciseOutput>();
            
            foreach(var input in inputsRequest)
            {
                inputs.Add(new ExerciseInput()
                {
                    ExerciseId = exercise.Id,
                    Input = input.Input,
                });
            }

            this._exerciseInputRepository.AddRange(inputs);

            for(int i = 0; i < outputsRequest.Count; i++)
            {
                outputs.Add(new ExerciseOutput()
                {
                    ExerciseId = exercise.Id,
                    ExerciseInputId = inputs[i].Id,
                    Output = outputsRequest[i].Output
                });
            }

            this._exerciseOutputRepository.AddRange(outputs);

            return exercise;
        }
    }
}
