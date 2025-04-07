using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Group
{
    public class CreateGroupRequest
    {
        [Required(ErrorMessage = "Título é obrigatório")]
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
