namespace Soccer.Web.Application.Responses
{
    public class GameResponse
    {
        public GameResponse()
        {
            GameTeams = new List<GameTeam>();
        }

        public Guid Id { get; set; }
        public List<GameTeam> GameTeams { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool IsGameOver { get; set; }
    }
}
