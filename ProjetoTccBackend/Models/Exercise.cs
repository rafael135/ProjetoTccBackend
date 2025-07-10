using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    /// <summary>
    /// Represents a programming exercise, including its metadata, description, estimated time, and related entities.
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Unique identifier for the exercise.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the exercise.
        /// </summary>
        [StringLength(200)]
        public required string Title { get; set; }

        /// <summary>
        /// Detailed description of the exercise.
        /// </summary>
        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }

        /// <summary>
        /// Estimated time to solve the exercise.
        /// </summary>
        public TimeSpan EstimatedTime { get; set; }

        /// <summary>
        /// UUID used by the judge system to identify the exercise.
        /// </summary>
        [StringLength(36, ErrorMessage = "UUID do exercício inválido")]
        public string? JudgeUuid { get; set; }

        /// <summary>
        /// Date and time when the exercise was created.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Collection of input examples for the exercise.
        /// </summary>
        public ICollection<ExerciseInput> ExerciseInputs { get; set; } = [];

        /// <summary>
        /// Collection of output examples for the exercise.
        /// </summary>
        public ICollection<ExerciseOutput> ExerciseOutputs { get; set; } = [];

        /// <summary>
        /// Competitions in which this exercise is included.
        /// </summary>
        public ICollection<Competition> Competitions { get; set; } = [];

        /// <summary>
        /// Collection of associations between this exercise and competitions.
        /// </summary>
        public ICollection<ExerciseInCompetition> ExerciseInCompetions { get; set; } = [];

        /// <summary>
        /// Attempts made by groups to solve this exercise.
        /// </summary>
        public ICollection<GroupExerciseAttempt> GroupExerciseAttempts { get; set; } = [];

        /// <summary>
        /// Questions related to this exercise.
        /// </summary>
        public ICollection<Question> Questions { get; set; } = [];
    }
}
