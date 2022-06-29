namespace Soccer.Web.Models
{
    public class GameModel
    {
        public GameModel()
        {
            GameTeams = new List<TeamScoreModel>();
        }

        public Guid Id { get; set; }
        public List<TeamScoreModel> GameTeams { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
