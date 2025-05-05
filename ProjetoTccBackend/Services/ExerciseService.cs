﻿using ProjetoTccBackend.Database.Requests.Exercise;
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
        private readonly IJudgeService _judgeService;
        private readonly ILogger<ExerciseService> _logger;

        public ExerciseService(IExerciseRepository exerciseRepository, IExerciseInputRepository exerciseInputRepository, IExerciseOutputRepository exerciseOutputRepository, IJudgeService judgeService, ILogger<ExerciseService> logger)
        {
            this._exerciseRepository = exerciseRepository;
            this._exerciseInputRepository = exerciseInputRepository;
            this._exerciseOutputRepository = exerciseOutputRepository;
            this._judgeService = judgeService;
            this._logger = logger;
        }

        public async Task<Exercise> CreateExerciseAsync(CreateExerciseRequest request)
        {
            string? judgeUuid = await this._judgeService.CreateJudgeExerciseAsync(request);

            if (judgeUuid == null)
            {
                throw new ErrorException(new
                {
                    Message = "Não foi possível criar o exercício"
                });
            }

            var inputsRequest = request.Inputs.ToList();
            var outputsRequest = request.Outputs.ToList();

            Exercise exercise = new Exercise()
            {
                JudgeUuid = judgeUuid,
                Title = request.Title,
                Description = request.Description,
                EstimatedTime = request.EstimatedTime,
            };

            this._exerciseRepository.Add(exercise);

            List<ExerciseInput> inputs = new List<ExerciseInput>();
            List<ExerciseOutput> outputs = new List<ExerciseOutput>();

            foreach (var input in inputsRequest)
            {
                inputs.Add(new ExerciseInput()
                {
                    ExerciseId = exercise.Id,
                    Input = input.Input,
                });
            }

            this._exerciseInputRepository.AddRange(inputs);

            for (int i = 0; i < outputsRequest.Count; i++)
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

        public async Task<Exercise?> GetExerciseByIdAsync(int id)
        {
            Exercise? exercise = this._exerciseRepository.GetById(id);
            return exercise;
        }
    }
}
