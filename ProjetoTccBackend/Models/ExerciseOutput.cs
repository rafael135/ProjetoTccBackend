using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class ExerciseOutput
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int ExerciseInputId { get; set; }
        public ExerciseInput ExerciseInput { get; set; }

        [DataType(DataType.MultilineText)]
        public string Output { get; set; }
    }
}
