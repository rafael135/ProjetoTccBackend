namespace ProjetoTccBackend.Models
{
    public class ExerciseInCompetition
    {
        public int ExerciseId { get; set; }
        public int CompetitionId { get; set; }
        public Exercise Exercise { get; set; } = null;
        public Competition Competition { get; set; } = null;
    }
}
