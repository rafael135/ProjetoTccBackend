using ProjetoTccBackend.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Database.Requests.Exercise
{
    public class ExerciseOutputRequest
    {
        public int? ExerciseId { get; set; }
        public int? ExerciseInputId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public string Output { get; set; }
    }
}
