namespace ProjetoTccBackend.Database.Responses.Exercise
{
    public class ExerciseResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ExerciseInputResponse> Inputs { get; set; }
        public ICollection<ExerciseOutputResponse> Outputs { get; set; }
    }
}
