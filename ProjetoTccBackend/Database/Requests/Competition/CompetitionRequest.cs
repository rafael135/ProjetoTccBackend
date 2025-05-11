using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Competition
{
    public class CompetitionRequest
    {
        [Required]
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [Required]
        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

    }
}
