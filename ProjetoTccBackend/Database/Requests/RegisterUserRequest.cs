using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Database.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        [MaxLength(6, ErrorMessage = "RA inválido!")]
        [MinLength(5, ErrorMessage = "RA inválido!")]
        public required string RA {  get; set; }

        [Required]
        [MaxLength(90, ErrorMessage = "Nome maior que 90 caracteres")]
        public required string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public required string Email { get; set; }

        [Required]
        public required int JoinYear { get; set; }
        
        [Required]
        public required string Password { get; set; }
    }
}
