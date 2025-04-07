using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Auth
{
    public class LoginUserRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [JsonPropertyName("password")]
        public required string Password { get; set; }
    }
}
