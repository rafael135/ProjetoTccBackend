using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Database.Requests.Auth
{
    public class LoginUserRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public required string Password { get; set; }
    }
}
