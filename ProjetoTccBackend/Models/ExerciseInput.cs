using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class ExerciseInput
    {
        [Key]
        public int  Id { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        [DataType(DataType.MultilineText)]
        public string Input { get; set; }

        public ExerciseOutput ExerciseOutput { get; set; }
    }
}
