using ProjetoTccBackend.Models;
using ProjetoTccBackend.Services.Interfaces;
using ProjetoTccBackend.Database.Responses.Judge;
using ProjetoTccBackend.Repositories.Interfaces;
using ProjetoTccBackend.Database.Requests.Exercise;
using ProjetoTccBackend.Database.Requests.Judge;
using System.Net;

namespace ProjetoTccBackend.Services
{
    public class JudgeService : IJudgeService
    {
        private HttpClient _httpClient;
        private IExerciseRepository _exerciseRepository;

        public JudgeService(IHttpClientFactory httpClientFactory, IExerciseRepository exerciseRepository)
        {
            this._httpClient = httpClientFactory.CreateClient("JudgeAPI");
            this._exerciseRepository = exerciseRepository;
        }

        public async Task<string?> CreateJudgeExerciseAsync(CreateExerciseRequest exerciseRequest)
        {
            CreateJudgeExerciseRequest payload = new CreateJudgeExerciseRequest()
            {
                Name = exerciseRequest.Title,
                Description = exerciseRequest.Description,
                DataEntry = exerciseRequest.Inputs.ToList()[0].Input,
                DataOutput = exerciseRequest.Outputs.ToList()[0].Output,
                EntryDescription = "",
                OutputDescription = ""
            };

            var result = await this._httpClient.PostAsJsonAsync<CreateJudgeExerciseRequest>("/problems", payload);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                JudgeExerciseResponse? exerciseResponse = await result.Content.ReadFromJsonAsync<JudgeExerciseResponse>();

                if (exerciseResponse != null)
                {
                    return exerciseResponse.Id;
                }
            }

            return null;
        }
        public async Task<Exercise?> GetExerciseByUuidAsync(string judgeUuid)
        {
            var judgeExercise = await this._httpClient.GetFromJsonAsync<JudgeExerciseResponse>($"/problems/{judgeUuid}");

            if(judgeExercise is null)
            {
                return null;
            }

            var exercise = this._exerciseRepository.Find((x) => x.JudgeUuid!.Equals(judgeUuid)).FirstOrDefault();

            return exercise;
        }

        public Task<ICollection<Exercise>> GetExercisesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateNewExerciseAsync(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
