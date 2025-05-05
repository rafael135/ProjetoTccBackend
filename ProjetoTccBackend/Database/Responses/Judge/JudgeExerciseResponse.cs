using ProjetoTccBackend.Database.Requests.Judge;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Responses.Judge
{
    public class JudgeExerciseResponse : CreateJudgeExerciseRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
