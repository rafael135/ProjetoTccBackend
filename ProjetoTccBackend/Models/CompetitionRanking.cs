using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTccBackend.Models
{
    public class CompetitionRanking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }

        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public float Points { get; set; } = 0.0F;

        public int RankOrder { get; set; }
    }
}
