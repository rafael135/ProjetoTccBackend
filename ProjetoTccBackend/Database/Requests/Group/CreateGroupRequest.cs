using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Group
{
    public class CreateGroupRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
