using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; } = [];

        public ICollection<Competition> Competitions { get; } = [];
        public ICollection<GroupInCompetition> GroupInCompetitions { get; } = [];

        public ICollection<CompetitionRanking> CompetitionRankings { get; } = [];
        public ICollection<GroupExerciseAttempt> GroupExerciseAttempts { get; set; } = [];
    }
}
