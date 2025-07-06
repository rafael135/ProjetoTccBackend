﻿using ProjetoTccBackend.Enums.Question;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
        /// <summary>  
        /// Represents a question that can be associated with an exercise or another question.  
        /// </summary>  
        public class Question
        {
            /// <summary>  
            /// Unique identifier of the question.  
            /// </summary>  
            [Key]
            public int Id { get; set; }

            /// <summary>  
            /// Target question identifier, if any.  
            /// </summary>  
            public int? TargetQuestionId { get; set; } = null;

            /// <summary>  
            /// Reference to the target question, if any.  
            /// </summary>  
            public Question? TargetQuestion { get; set; } = null;

            /// <summary>  
            /// Identifier of the exercise associated with the question, if any.  
            /// </summary>  
            public int? ExerciseId { get; set; } = null;

            /// <summary>  
            /// Reference to the exercise associated with the question, if any.  
            /// </summary>  
            public Exercise? Exercise { get; set; } = null;

            /// <summary>  
            /// Textual content of the question.  
            /// </summary>  
            [DataType(DataType.MultilineText)]
            public required string Content { get; set; }
        
            /// <summary>  
            /// Type of the question, indicating its nature.  
            /// </summary>  
            public QuestionType QuestionType { get; set; }
        }
}
