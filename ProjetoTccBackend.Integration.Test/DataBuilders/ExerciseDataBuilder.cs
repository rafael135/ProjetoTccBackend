using Bogus;
using ProjetoTccBackend.Models;

namespace ProjetoTccBackend.Integration.Test.DataBuilders
{
    public class ExerciseDataBuilder : Faker<Exercise>
    {
        public int? Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
        public TimeSpan? EstimatedTime { get; set; }

        public string? JudgeUuid { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ExerciseDataBuilder()
        {
            CustomInstantiator(e =>
            {
                int id = e.Random.Int();
                string title = e.Lorem.Word();
                string description = e.Lorem.Paragraph();
                TimeSpan estimatedTime = e.Date.Timespan();
                string judgeUuid = e.Database.Random.Uuid().ToString();
                DateTime createdAt = e.Date.Past(2, DateTime.Now);

                return new Exercise()
                {
                    Id = (this.Id != null) ? (int)this.Id : id,
                    JudgeUuid = (this.JudgeUuid != null) ? this.JudgeUuid : judgeUuid,
                    Title = (this.Title != null) ? this.Title : title,
                    Description = (this.Description != null) ? this.Description : description,
                    EstimatedTime = (this.EstimatedTime != null) ? (TimeSpan)this.EstimatedTime : estimatedTime,
                    CreatedAt = (this.CreatedAt != null) ? this.CreatedAt : createdAt,
                    ExerciseInputs = new ExerciseInputDataBuilder().GenerateBetween(1, 6).ToList(),
                    ExerciseOutputs = new ExerciseOutputDataBuilder().GenerateBetween(1, 6).ToList()
                };
            });
        }

        public Exercise Build() => Generate();
    }
}
