namespace Soccer.Web.Application.Responses
{
    public class GameTeam
    {
        public Guid TeamId { get; set; }
        public int Score { get; set; }
        public bool? GameWon { get; internal set; }
    }
}
