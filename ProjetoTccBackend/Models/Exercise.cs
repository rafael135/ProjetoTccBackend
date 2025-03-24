using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        public ICollection<ExerciseInput> ExerciseInputs { get; set; } = [];
        public ICollection<ExerciseOutput> ExerciseOutputs { get; set; } = [];
        public ICollection<Competition> Competitions { get; set; } = [];
        public ICollection<ExerciseInCompetition> ExerciseInCompetions { get; set; } = [];
        public ICollection<GroupExerciseAttempt> GroupExerciseAttempts { get; set; } = [];
    }
}
