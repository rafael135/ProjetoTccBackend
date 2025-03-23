using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Database.Requests.Auth
{
    public class RegisterUserRequest
    {
        [Required]
        [MaxLength(6, ErrorMessage = "RA inválido!")]
        [MinLength(5, ErrorMessage = "RA inválido!")]
        [JsonPropertyName("ra")]
        public string RA {  get; set; }

        [Required]
        [MaxLength(90, ErrorMessage = "Nome maior que 90 caracteres")]
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("joinYear")]
        public int JoinYear { get; set; }
        
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
