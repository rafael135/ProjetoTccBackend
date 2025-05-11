using Bogus;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Integration.Test.DataBuilders
{
    public class ExerciseInputDataBuilder : Faker<ExerciseInput>
    {
        public int? Id { get; set; }

        public int? ExerciseId { get; set; }

        public string? JudgeUuid { get; set; }

        public string? Input { get; set; }

        public ExerciseInputDataBuilder()
        {
            CustomInstantiator(u =>
            {
                Random random = new Random();

                int id = u.Random.Int();
                string judgeUuid = u.Database.Random.Uuid().ToString();
                int exerciseId = u.Random.Int();
                string input = u.Lorem.Lines(5);

                return new ExerciseInput()
                {
                    Id = (this.Id != null) ? (int)this.Id : id,
                    ExerciseId = (this.ExerciseId != null) ? (int)this.ExerciseId : exerciseId,
                    JudgeUuid = (this.JudgeUuid != null) ? this.JudgeUuid : judgeUuid,
                    Input = (this.Input != null) ? this.Input : input,
                };

            });
        }

        public ExerciseInput Build() => Generate();
    }
}
