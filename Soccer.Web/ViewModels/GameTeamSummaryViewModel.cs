namespace Soccer.Web.ViewModels
{
    public class GameTeamSummaryViewModel
    {
        public string TeamName { get; set; } = null!;
        public int Score { get; set; }
        public bool? GameWon { get; set; }
    }
}
