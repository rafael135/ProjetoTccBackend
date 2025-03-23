namespace ProjetoTccBackend.Database.Responses.Exercise
{
    public class ExerciseOutputResponse
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int ExerciseInputId { get; set; }

        public string Output { get; set; }
    }
}
