namespace Soccer.Web.Models
{
    public class GameTeamModel
    {
        public Guid TeamId { get; set; }
        public int Score { get; set; }
        public bool? GameWon { get; internal set; }
    }
}
