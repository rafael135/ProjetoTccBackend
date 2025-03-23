using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Database.Requests.Exercise
{
    public class ExerciseInputRequest
    {
        public int? ExerciseId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Input { get; set; }
    }
}
