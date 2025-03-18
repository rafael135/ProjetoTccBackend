using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public ICollection<Competition> Competitions { get; set; } = [];
        public ICollection<ExerciseInCompetition> ExercideInCompetions { get; set; } = [];
    }
}
