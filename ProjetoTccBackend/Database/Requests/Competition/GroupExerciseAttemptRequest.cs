using ProjetoTccBackend.Enums.Exercise;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Competition
{
    public class GroupExerciseAttemptRequest
    {
        [JsonPropertyName("exerciseId")]
        public int ExerciseId { get; set; }

        [JsonPropertyName("languageType")]
        public LanguageType LanguageType { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
