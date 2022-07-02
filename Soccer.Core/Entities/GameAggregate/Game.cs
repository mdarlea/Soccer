using Soccer.Core.Entities.TeamAggregate;
using Soccer.Core.Interfaces;

namespace Soccer.Core.Entities.GameAggregate
{
    public class Game : EntityBase, IAggregateRoot
    {
       
        private readonly List<GameTeam> gameTeams = new();
        public IReadOnlyCollection<GameTeam> GameTeams => gameTeams.AsReadOnly();

        public DateTimeOffset DateAndTime { get; set; }
        public bool IsGameOver { get; private set; }

        private Game()
        {
            // required for EF
        }

        public Game(DateTimeOffset dateAndTime)
        {
            DateAndTime = dateAndTime;
        }

        public IReadOnlyCollection<Team> Teams
        {
            get
            {
                return gameTeams.Select(gt => gt.Team).ToList().AsReadOnly();
            }
        }

        public void AddTeam(Team team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));

            if (!GameTeams.Any(p => p.Team.Id == team.Id))
            {
                var scoreEntity = new GameTeam(this, team);
                gameTeams.Add(scoreEntity);
            }
        }

        public void AddScore(Team team, int score)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));

            var gameScore = GameTeams.FirstOrDefault(s => s.Team.Id == team.Id);
            if (gameScore == null)
            {
                gameScore = new GameTeam(this, team);
                gameTeams.Add(gameScore);
            }

            gameScore.Score = score;
        }

        public void SetFinalScore()
        {
            IsGameOver = true;

            var winningScore = gameTeams.Max(gt => gt.Score);

            foreach (var gameTeam in gameTeams)
            {
                gameTeam.GameWon = gameTeam.Score == winningScore;
            }
        }
    }
}
