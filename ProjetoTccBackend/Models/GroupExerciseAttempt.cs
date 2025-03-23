using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class GroupExerciseAttempt
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Code { get; set; }
    }
}
