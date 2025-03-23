using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Database.Requests.Group
{
    public class CreateGroupRequest
    {
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Title { get; set; }
    }
}
