using ProjetoTccBackend.Enums.Judge;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Responses.Competition
{
    public class ExerciseSubmissionResponse
    {
        [JsonPropertyName("exerciseId")]
        public int ExerciseId { get; set; }

        [JsonPropertyName("groupId")]
        public int GroupId { get; set; }

        [JsonPropertyName("accepted")]
        public bool Accepted { get; set; }

        [JsonPropertyName("judgeResponse")]
        public JudgeSubmissionResponse JudgeResponse { get; set; }

    }
}
