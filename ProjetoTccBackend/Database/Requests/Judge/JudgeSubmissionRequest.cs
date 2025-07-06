using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Judge
{
    public class JudgeSubmissionRequest
    {
        [JsonPropertyName("problem_id")]
        public string ProblemId { get; set; }
        [JsonPropertyName("language_type")]
        public string LanguageType { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

    }
}
