namespace ProjetoTccBackend.Models
{
    public class GroupInCompetition
    {
        public int GroupId { get; set; }
        public int CompetitionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Group Group { get; set; } = null;
        public Competition Competition { get; set; } = null;
    }
}
