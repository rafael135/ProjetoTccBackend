using ProjetoTccBackend.Database.Requests.Judge;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Responses.Judge
{
    public class JudgeSubmissionResponse : JudgeSubmissionRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
