using ProjetoTccBackend.Enums.Exercise;
using ProjetoTccBackend.Enums.Judge;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class GroupExerciseAttempt
    {
        [Key]
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime SubmissionTime { get; set; } = DateTime.Now;
        public LanguageType Language { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        [DataType(DataType.Text)]
        public string Code { get; set; }

        public bool Accepted { get; set; }
        public JudgeSubmissionResponse JudgeResponse { get; set; }
    }
}
