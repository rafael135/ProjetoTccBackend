using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Exercise
{
    public class CreateExerciseRequest
    {
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required]
        [JsonPropertyName("estimatedTime")]
        public TimeSpan EstimatedTime { get; set; }

        public ICollection<ExerciseInputRequest> Inputs { get; set; }
        public ICollection<ExerciseOutputRequest> Outputs { get; set; }

    }
}
