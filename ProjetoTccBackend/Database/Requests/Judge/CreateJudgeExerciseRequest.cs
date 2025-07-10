using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Judge
{
    public class CreateJudgeExerciseRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("data_entry")]
        public ICollection<string> DataEntry { get; set; }

        [JsonPropertyName("entry_description")]
        public string EntryDescription { get; set; }

        [JsonPropertyName("data_output")]
        public ICollection<string> DataOutput { get; set; }

        [JsonPropertyName("output_description")]
        public string OutputDescription { get; set; }
    }
}
