namespace Soccer.Web.ViewModels
{
    public class SelectTeamViewModel
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public bool IsSelected { get; set; }
        public int Score { get; set; }
    }
}
