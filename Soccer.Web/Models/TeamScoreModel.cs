namespace Soccer.Web.Models
{
    public class TeamScoreModel
    {
        public Guid TeamId { get; set; }
        public int Score { get; set; }
        public bool? GameWon { get; internal set; }
    }
}
