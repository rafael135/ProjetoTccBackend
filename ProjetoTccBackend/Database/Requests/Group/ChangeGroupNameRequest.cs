using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Group
{
    public class ChangeGroupNameRequest
    {
        [Required(ErrorMessage = "Campo 'id' obrigatório")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'name' obrigatório")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
