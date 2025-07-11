﻿using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class ExerciseOutput
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        [StringLength(36, ErrorMessage = "UUID do exercício inválido")]
        public string? JudgeUuid { get; set; }
        public Exercise Exercise { get; set; }

        public int ExerciseInputId { get; set; }
        public ExerciseInput ExerciseInput { get; set; }

        [DataType(DataType.Text)]
        public string Output { get; set; }
    }
}
