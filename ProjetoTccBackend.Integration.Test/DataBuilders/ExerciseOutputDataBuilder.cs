using Bogus;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Integration.Test.DataBuilders
{
    public class ExerciseOutputDataBuilder : Faker<ExerciseOutput>
    {
        public int? Id { get; set; }

        public int? ExerciseId { get; set; }

        public int? ExerciseInputId { get; set; }

        public string? JudgeUuid { get; set; }

        public string? Output { get; set; }

        public ExerciseOutputDataBuilder()
        {
            CustomInstantiator(u =>
            {
                Random random = new Random();

                int id = u.Random.Int();
                string judgeUuid = u.Database.Random.Uuid().ToString();
                int exerciseId = u.Random.Int();
                int exerciseInputId = u.Random.Int();
                string output = u.Lorem.Lines(5);

                return new ExerciseOutput()
                {
                    Id = (this.Id != null) ? (int)this.Id : id,
                    ExerciseId = (this.ExerciseId != null) ? (int)this.ExerciseId : exerciseId,
                    ExerciseInputId = (this.ExerciseInputId != null) ? (int)this.ExerciseInputId : exerciseInputId,
                    JudgeUuid = (this.JudgeUuid != null) ? this.JudgeUuid : judgeUuid,
                    Output = (this.Output != null) ? this.Output : output,
                    
                };

            });
        }

        public ExerciseOutput Build() => Generate();
    }
}
