using ProjetoTccBackend.Database.Requests.Competition;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Responses.Competition
{
    public class CompetitionResponse : CompetitionRequest
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
