using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class GroupExerciseAttempt
    {
        [Key]
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [DataType(DataType.MultilineText)]
        public string Code { get; set; }
    }
}
