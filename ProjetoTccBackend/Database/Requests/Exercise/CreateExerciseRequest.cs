using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Database.Requests.Exercise
{
    public class CreateExerciseRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        public ICollection<ExerciseInputRequest> Inputs { get; set; }
        public ICollection<ExerciseOutputRequest> Outputs { get; set; }

    }
}
