using ProjetoTccBackend.Enums.Exercise;

namespace ProjetoTccBackend.Enums.Question
{
    /// <summary>
    /// Enum that represents the different types of questions.
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// General question.
        /// </summary>
        General = 0,

        /// <summary>
        /// Question related to exercises.
        /// </summary>
        Exercise = 1,

        /// <summary>
        /// Question related to problems or issues.
        /// </summary>
        Issue = 2,
    }
}
