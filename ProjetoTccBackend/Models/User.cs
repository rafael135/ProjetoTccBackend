using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccBackend.Models
{
    public class User : IdentityUser
    {
        public int? JoinYear { get; set; }
        public string RA { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
