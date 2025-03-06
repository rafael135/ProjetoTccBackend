using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetoTccBackend.Models
{
    public class User : IdentityUser
    {
        public int JoinYear { get; set; }
    }
}
