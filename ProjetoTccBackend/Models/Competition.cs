using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
        
        [Required]
        public DateTime EndTime { get; set; }

        public ICollection<Group> Groups { get; } = [];
        public ICollection<GroupInCompetition> GroupInCompetitions { get; } = [];

        public ICollection<Exercise> Exercices { get; } = [];
        public ICollection<ExerciseInCompetition> ExercisesInCompetition { get; } = [];

        public CompetitionRanking CompetitionRanking { get; set; } = null;
    }
}
