namespace Soccer.Web.Models
{
    public class GameModel
    {
        public GameModel()
        {
            GameTeams = new List<GameTeamModel>();
        }

        public Guid Id { get; set; }
        public List<GameTeamModel> GameTeams { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool IsGameOver { get; set; }
    }
}
