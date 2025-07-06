namespace ProjetoTccBackend.Exceptions.Judge
{
    public class JudgeException : Exception
    {
        private object ExerciseInfo { get; set; }

        public JudgeException()
        {

        }

        public JudgeException(string message) : base(message)
        {

        }

        public JudgeException(object obj)
        {
            ExerciseInfo = obj;
        }

        public JudgeException(string message, object obj) : base(message)
        {
            ExerciseInfo = obj;
        }
    }
}
