using Soccer.Web.Models;

namespace Soccer.Web.Features.Commands.GameCommands
{
    public abstract class BaseGameCommand
    {
        protected BaseGameCommand()
        {
            TeamScores = new List<GameTeamModel>();
        }

        public List<GameTeamModel> TeamScores { get; set; }
        public bool IsGameOver { get; set; }
    }
}
